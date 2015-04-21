using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour {

	public GameObject[] missionarray = new GameObject[5];
	public GameObject selectedmission;

	public void SelectMission(int missionlevel, GameObject startingtile){
		selectedmission.GetComponent<Mission> ().missionlevel = missionlevel;
		selectedmission.GetComponent<Mission> ().startingtile = startingtile;
		Debug.Log ("level" + missionlevel + "and tile" + startingtile);
		DontDestroyOnLoad (this);
		//Application.LoadLevel ("test");
		Instantiate (selectedmission.GetComponent<Mission>().startingtile);
		}
}