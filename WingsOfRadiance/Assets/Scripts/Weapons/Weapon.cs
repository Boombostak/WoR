using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    public int basedamage;
    public float floatdamage;
    public int finaldamage;
    private float shot_delay;
    public float baserof;
    public float finalrof; //shots per second
    public GameObject projectile;
    public GameObject player;
    public PlayerTraits playertraits;
    private float shot_countup = 0f;
    private bool ready_to_shoot;
    public float basedps;
    public float finaldps;
    public string shootbutton;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playertraits = player.GetComponent<PlayerTraits>();
        floatdamage = (float)basedamage * playertraits.damage_multiplier + (float)playertraits.damage_bonus;
        finaldamage = (int)floatdamage;
        finalrof = baserof * playertraits.rof_multiplier;
        shot_delay = 1 / finalrof;
        basedps = baserof * (float)basedamage;
        finaldps = finalrof * (float)finaldamage;

        if (this.transform.gameObject == player.transform.GetChild(0).gameObject)
	{
        shootbutton = "Fire1";
	}
        if (this.transform == player.transform.GetChild(1))
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
            Instantiate(projectile, this.transform.position, this.transform.rotation);
            shot_countup = 0;
    }
}