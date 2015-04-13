using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour {

    public GameObject weaponGO;
    public GameObject[] originarray;
    public float rof;
    public float shots_per_second;
    public int damage;
    private GameObject player;
    private GameObject thisenemy;
    private int hardpoints;
    private int originmax;
    public GameObject projectile;
    private GameObject proj_instance;
    private bool ready_to_shoot;

    void Awake()
    {
        proj_instance = projectile;
    }
    
    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        thisenemy = this.gameObject;
        rof = 1 / shots_per_second;
        InitializeOrigins();
	}

    void InitializeOrigins()
    {
        hardpoints = thisenemy.transform.Find("hardpoints").childCount;

        if (hardpoints > originarray.Length)
        {
            originmax = originarray.Length;
        }
        else
        {
            originmax = hardpoints;
        }
        
        for (int i = 0; i < originmax; i++)
        {
            originarray[i].transform.parent = thisenemy.transform.Find("hardpoints").GetChild(i);
            originarray[i].transform.localPosition = Vector3.zero;
        }
    }

    IEnumerator ShotCountdown()
    {
        ready_to_shoot = false;
        yield return new WaitForSeconds(rof);
        ready_to_shoot = true;
    }

    public void Shoot()
    {
        foreach (GameObject i in originarray)
        {
            Instantiate(proj_instance, i.transform.position, i.transform.rotation);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (this.renderer.isVisible && ready_to_shoot)
        {
            Shoot();
            StartCoroutine(ShotCountdown());
        }
	
	}
}
