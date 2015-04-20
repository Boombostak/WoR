using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour {

	public GameObject[] missionarray = new GameObject[5];
	public GameObject selectedmission;

	void Start(){
		for (int i = 0; i < missionarray.Length; i++) {
			
				}
		selectedmission = missionarray [Random.Range (0, missionarray.Length)];
		Instantiate (selectedmission.GetComponent<Mission>().startingtile);
	}
}