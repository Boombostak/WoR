using UnityEngine;
using System.Collections;

static class bullet : MonoBehaviour
{

    public Vector2 position;
    public Vector2 direction;
    float collision_size;
    int unique_id;
    int active;
    Appearance *appearance;
    Behaviour *behaviour;
}