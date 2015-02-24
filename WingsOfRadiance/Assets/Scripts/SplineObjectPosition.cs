using UnityEngine;
using System.Collections;

public class SplineObjectPosition : MonoBehaviour
{

    public GameObject spline_object;
    public GameObject[] collider_object_array;
    public int number_of_objects = 20; //equivalent to line_renderer_verts
    public GameObject currentcollider;
}