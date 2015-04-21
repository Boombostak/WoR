using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerTraits : MonoBehaviour {

    
    public string playername;
    //basic stats
    public int xp;
    public int gunnery_skill;
    public int reflexes_skill;
    public int tech_skill;
    //derived stats
    public int playerlvl;
    public int matter_max;
    public int energy_max;
    public int damage_reduction;
    public int damage_bonus;
    public float damage_multiplier;
    public float rof_multiplier;
    public int avoid_chance;
    public int mass_absorbtion;
    public int energy_absorbtion;
    public int bounty_collection;
	public int reputation;//positive means good vibes with union, negative means good vibes with corps.

    //dynamic values
    public int currentmatter;
	public int currentenergy;
	public int credits;

    public float dps;

    

    void Awake()
    {
        for (int i = 0; i < ExperienceTable.xp_for_level_i.Length; i++)
        {
            if (xp >= ExperienceTable.xp_for_level_i[i])
            {
                playerlvl = i;
            }
        }
        

        currentmatter = matter_max;
        currentenergy = energy_max;
    }
    
    void Update()
    {
        if (currentmatter < 1)
        {
            PlayerDied();
        }
    }

    void PlayerDied()
    {
        Debug.Log("Player has died");
    }
}
