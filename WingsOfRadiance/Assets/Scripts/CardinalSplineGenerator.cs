using UnityEngine;
using System.Collections;

public class CardinalSplineGenerator : MonoBehaviour
{

    //P_sub_i = ((P_sub_i + 1)-(P_sub_i - 1))/alpha

    public GameObject[] controlpoints;
    public int num_points = 5;
    public GameObject cp_prefab;
    public Vector2 splinevector;
    public GameObject player;
    public float alignmentbias;
    public Vector3 alignmentvector;
    public bool lock5;
    public bool lock4;
    public bool lock3;
    public bool lock2;
    public int line_renderer_verts = 20;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        alignmentvector.x = alignmentbias;
        alignmentvector.y = 1;
        controlpoints = new GameObject[num_points];
        for (int i = 0; i < num_points; i++)
        {
            controlpoints[i] = (GameObject)Instantiate(cp_prefab);
        }
    }

    // Update is called once per frame

    //We want the spline to shoot straight when the ship is still and there are no enemies
    //We want the control points to move with the movement of the ship
    //We want the control points to snap to nearby enemies until they are dead or off-screen
    //

    public void ConstructControlPoints()
    {
 
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
            && lock4 == true)
        {
            controlpoints[2].transform.position = GetComponent<FindNearestEnemy>().closest.transform.position;
            lock3 = true;
        }
        else
        {
            controlpoints[2].transform.position = player.transform.position + alignmentvector;
        }


    }

    public void DrawCurve()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetVertexCount(line_renderer_verts);
        // set points of Hermite curve
        Vector3 p0;
        Vector3 p1;
        Vector3 m0;
        Vector3 m1;
        float t;
        Vector3 position;
        float pointstep = 1 / line_renderer_verts;

        for (int j = 0; j < controlpoints.Length - 1; j++)
        {
            // check control points
            if (controlpoints[j] == null ||
               controlpoints[j + 1] == null ||
               (j > 0 && controlpoints[j - 1] == null) ||
               (j < controlpoints.Length - 2 &&
               controlpoints[j + 2] == null))
            {
                return;
            }
            // determine control points of segment
            p0 = controlpoints[j].transform.position;
            p1 = controlpoints[j + 1].transform.position;
            if (j > 0)
            {
                m0 = 0.5f * (controlpoints[j + 1].transform.position
                - controlpoints[j - 1].transform.position);
            }
            else
            {
                m0 = controlpoints[j + 1].transform.position
                - controlpoints[j].transform.position;
            }
            if (j < controlpoints.Length - 2)
            {
                m1 = 0.5f * (controlpoints[j + 2].transform.position
                - controlpoints[j].transform.position);
            }
            else
            {
                m1 = controlpoints[j + 1].transform.position
                - controlpoints[j].transform.position;
            }

            if (j==controlpoints.Length -2)
            {
                pointstep = 1 / (line_renderer_verts - 1f);
            }

            for (int i = 0; i < line_renderer_verts; i++)
            {
                t = i *pointstep;
                position.x = (2.0f * t * t * t - 3.0f * t * t + 1) * p0.x
                   + (t * t * t - 2.0f * t * t + t) * m0.x
                   + (-2.0f * t * t * t + 3.0f * t * t) * p1.x
                   + (t * t * t - t * t) * m1.x;
                position.y = (2f * t * t * t - 3f * t * t + 1) * p0.y
                  + (t * t * t - 2f * t * t + t) * m0.y
                  + (-2f * t * t * t + 3f * t * t) * p1.y
                  + (t * t * t - t * t) * m1.y;
                position.z = 0f;
                lineRenderer.SetPosition(i, position);
            }
        }
    }

    void Update()
    {
        ConstructControlPoints();
        DrawCurve();
    }
}