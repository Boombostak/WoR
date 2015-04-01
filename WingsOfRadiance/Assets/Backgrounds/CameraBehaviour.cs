using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{

    public Camera camera;
    public SpriteRenderer backgroundrenderer;
    public Bounds background_snapshot;
    public player_movement playermovement;

    void Start()
    {
        camera = this.GetComponent<Camera>();
        background_snapshot = backgroundrenderer.bounds;
    }

    void Update()
    {
        camera.transform.Translate(playermovement.movement_return.x / 2, 0, 0);
        Mathf.Clamp(camera.rect.xMin, background_snapshot.min.x, (background_snapshot.max.x - camera.rect.x));
        Mathf.Clamp(camera.rect.xMax, (background_snapshot.min.x + camera.rect.width), background_snapshot.max.x);
    }


}