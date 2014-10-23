using UnityEngine;
using System.Collections;

public class CardinalSplineGenerator : MonoBehaviour {

	//P_sub_i = ((P_sub_i + 1)-(P_sub_i - 1))/alpha

    public GameObject[] controlpoints;
    public Vector2 splinevector;
    public GameObject player;
    public float alignmentbias;
    public Vector3 alignmentvector;
    public bool lock5;
    public bool lock4;
    public bool lock3;
    public bool lock2;
    

    // Use this for initialization
	void Start () {
        
        player = GameObject.FindGameObjectWithTag("Player");
        alignmentvector.x = alignmentbias;
        alignmentvector.y = 1;
	}
	
	// Update is called once per frame
	
    //We want the spline to shoot straight when the ship is still and there are no enemies
    //We want the control points to move with the movement of the ship
    //We want the control points to snap to nearby enemies until they are dead or off-screen
    //
    
    void Update () {

        controlpoints[0].transform.position = player.transform.position;
        controlpoints[1].transform.position = player.transform.position;

        //controlpoint 4
        if (controlpoints[4].GetComponent<FindNearestEnemy>().distance < controlpoints[4].GetComponent<FindNearestEnemy>().mindist)
        {
            controlpoints[4].transform.position = GetComponent<FindNearestEnemy>().closest.transform.position;
            lock5 = true;
        }
        else
        {
            controlpoints[5].transform.position = player.transform.position + alignmentvector + alignmentvector + alignmentvector;
        }
        
        //controlpoint 5 follows 4
        controlpoints[5].transform.position = controlpoints[4].transform.position;

        
        //controlpoint 3
        if (controlpoints[3].GetComponent<FindNearestEnemy>().distance < controlpoints[3].GetComponent<FindNearestEnemy>().mindist 
            && lock5 == true)
        {
            controlpoints[3].transform.position = GetComponent<FindNearestEnemy>().closest.transform.position;
            lock4 = true;
        }
        else
        {
            controlpoints[3].transform.position = player.transform.position + alignmentvector + alignmentvector;
        }

        
        //controlpoint 2
        if (controlpoints[2].GetComponent<FindNearestEnemy>().distance < controlpoints[3].GetComponent<FindNearestEnemy>().mindist
            && lock5 == true
            && lock4 ==true)
        {
            controlpoints[2].transform.position = GetComponent<FindNearestEnemy>().closest.transform.position;
            lock3 = true;
        }
        else
        {
            controlpoints[2].transform.position = player.transform.position + alignmentvector;
        }      
        

	}
}
