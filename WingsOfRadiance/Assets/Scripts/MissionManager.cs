using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour {

	public GameObject[] missionarray = new GameObject[5];
	public GameObject selectedmission;

	public void SelectMission(int missionlevel, GameObject startingtile){
		missionlevel = selectedmission.GetComponent<Mission> ().missionlevel;
		startingtile = selectedmission.GetComponent<Mission> ().startingtile;

		DontDestroyOnLoad (this);
		Application.LoadLevel ("test");
		Instantiate (selectedmission.GetComponent<Mission>().startingtile);
		}
}