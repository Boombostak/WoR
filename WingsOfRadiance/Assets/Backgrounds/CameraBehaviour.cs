﻿using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{

    public bool TATE;
    public Camera camera;
    public SpriteRenderer backgroundrenderer;
    public static Bounds background_snapshot;
    public player_movement playermovement;
    public GameObject player;
    private float xmin;
    private float xmax;
    public Vector3 cameramovement;
    public float halfrect;

    void Awake()
    {
        camera = this.GetComponent<Camera>();
        
        background_snapshot = backgroundrenderer.bounds;
        xmin = background_snapshot.min.x;
        xmax = background_snapshot.max.x;

        if (TATE)
        {
            
            //halfrect = camera.ViewportToWorldPoint / 2f;
        }
        else
        {
            //halfrect = camera.ViewportToWorldPoint / 2f;
        }
    }
    
    void Start()
    {
    }

    void Update()
    {
        cameramovement = playermovement.movement_return / 2f;
        camera.transform.Translate(cameramovement);
        camera.transform.position = new Vector3((Mathf.Clamp(camera.transform.position.x, -3, 3)),
            Mathf.Clamp(camera.transform.position.y, 0,0),
            camera.transform.position.z);
    }


}