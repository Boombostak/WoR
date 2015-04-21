using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour {

	public GameObject[] missionarray = new GameObject[5];
	public GameObject selectedmission;

	public void SelectMission(int missionlevel, Mission selectedmission, GameObject startingtile){
		SharedVariables.startingtile = startingtile;
		SharedVariables.selectedmission = selectedmission;
		SharedVariables.selectedmission.missionlevel = missionlevel;
		SharedVariables.missionlevel = missionlevel;
		//this.gameObject.GetComponent<MissionManager> (). = SharedVariables.selectedmission;
		Debug.Log ("level" + missionlevel + "and tile" + startingtile);
		
		
		Debug.Log("SharedVars: PlayerLevel:" +SharedVariables.playerlevel +"MissionLevel:" +SharedVariables.missionlevel+"StartingTile:"+SharedVariables.startingtile+"Selectedmission:"+SharedVariables. selectedmission);

		DontDestroyOnLoad (this);
		//Application.LoadLevel ("test");
		Instantiate (startingtile);
		}
}