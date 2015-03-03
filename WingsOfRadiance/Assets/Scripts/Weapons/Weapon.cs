using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    int damage;
    int rof;
    public GameObject projectile;

    public void Shoot()
    {
        Instantiate(projectile, this.transform.position, this.transform.rotation);
    }
}