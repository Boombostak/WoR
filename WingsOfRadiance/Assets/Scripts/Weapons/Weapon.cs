using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    public int basedamage;
    public float floatdamage;
    public int finaldamage;
    public float base_proj_speed;
    public float final_proj_speed;
    private float shot_delay;
    public float baserof;
    public float finalrof; //shots per second
    public Projectile projectile;
    public Projectile proj_instance;
    public GameObject player;
    public PlayerTraits playertraits;
    private float shot_countup = 0f;
    private bool ready_to_shoot;
    public float basedps;
    public float finaldps;
    public string shootbutton;

    void Awake()
    {
        proj_instance = Instantiate(projectile) as Projectile;
    }
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playertraits = player.GetComponent<PlayerTraits>();
        floatdamage = (float)basedamage * playertraits.damage_multiplier + (float)playertraits.damage_bonus;
        finaldamage = (int)floatdamage;
        final_proj_speed = base_proj_speed * 1;//playertrait not set up
        finalrof = baserof * playertraits.rof_multiplier;
        shot_delay = 1 / finalrof;
        basedps = baserof * (float)basedamage;
        finaldps = finalrof * (float)finaldamage;

        proj_instance.damage = finaldamage;
        proj_instance.speed = final_proj_speed;

        

        if (this.transform == player.transform.GetChild(1).GetChild(0))
	    {
            shootbutton = "Fire1";
	    }
        
        if (this.transform == player.transform.GetChild(1).GetChild(1))
        {
            shootbutton = "Fire2";
        }
        
    }

    void Update()
    {
        shot_countup += Time.deltaTime;
        Debug.Log(shot_countup);
        
        if ((Input.GetButton(shootbutton)) && (shot_countup > shot_delay))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
            Instantiate(proj_instance, this.transform.position, this.transform.rotation);
            shot_countup = 0;
    }
}