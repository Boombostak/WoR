using UnityEngine;
using System.Collections;

public class MissionBuilder : MonoBehaviour {

	public GameObject player;
	public PlayerTraits playertraits;
	public GameObject startingtile;
	public Camera camera;

	void Awake(){
				player = GameObject.FindGameObjectWithTag ("Player");
				playertraits = player.GetComponent<PlayerTraits> ();
		}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
