using UnityEngine;
using System.Collections;

public class bullet_manager : MonoBehaviour {

    const uint MAX_BULLETS=2000; // inside a common include, at global scope, used at different places
    
    private Bullet *bullets;
    private uint *id_index_table; // basically this will be both, a mapping table and a linked list of IDs
    private uint active_bullets_count;
    private uint next_free_id_slot;
    
    public void BulletMananger;
    public int bullets = 0;
    public int id_index_table = 0;
    public int active_bullets_count = 0;
    public int next_free_id_slot =0;
    {
      int bullets =new [] Bullet[MAX_BULLETS];
      id_to_index_table=new unsigned int[MAX_BULLETS];
      // initialize the ID-index-table to form a linked list, each entry pointing to the next
      for(uint t=0;t<MAX_BULLETS;++t) id_index_table[t]=t+1;
    }
    ~BulletMananger(void) {
      delete[] id_to_index_table;
      delete[] bullets;
    }
    unsigned int Create(Bullet &p_bullet_description) {
      Bullet &l_new_bullet=bullets[active_bullets_count];
      l_new_bullet=p_bullet_description;
      l_new_bullet.active=1;
      unsigned int l_id=next_free_id_slot;
      l_new_bullet.id=l_id;
      // remember: next_free_id_slot contains the index of the next free ID, see initialization
      // now we store that index to the free ID list for the next bullet that's going to be created later...
      next_free_id_slot=id_index_table[l_id];
      // ... and instead let the table now point to our bullet's array index!
      id_index_table[l_id]=active_bullets_count++;
      return l_id;
    }
    void Update(void) {
      unsigned int l_new_index=0;
      for(unsigned int t=0;t<active_bullets_count;++t) {
        Bullet &l_bullet=bullets[t];
        l_bullet.Update();
        if(l_bullet.active) {
          if(t!=l_new_index) {
            // if a bullet was destroyed before adjust the index-tables
            // and move the bullet down in the array accordingly.
            bullets[l_new_index]=l_bullet;
            id_index_table[l_bullet.id]=l_new_index;
          }
          ++l_new_index;
        } else {
          // when a bullet is removed we have to "fix" the free-IDs-pseudo-linked-list.
          // that's easy: we just let the bullet's slot point to the known next free ID
          // which we stored during bullet creation...
          id_index_table[l_bullet.id]=next_free_id_slot;
          // ... and make that slot the new "next_free" slot (like adjusting the head of a linked list)
          next_free_id_slot=l_bullet.id;
        }
      }
      active_bullets_count=l_new_index;
    }
    inline Bullet& GetBulletByID(unsigned int p_id) {
      return bullets[id_index_table[p_id]];
    }
    
    
};