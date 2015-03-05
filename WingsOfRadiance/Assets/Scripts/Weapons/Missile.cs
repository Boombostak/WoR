using UnityEngine;
using System.Collections;

public class Missile : Projectile {

	void Update () {
        transform.Translate(0, speed * Time.deltaTime, 0);
	}
}
