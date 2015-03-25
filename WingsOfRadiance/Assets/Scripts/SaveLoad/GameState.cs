using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameState : MonoBehaviour {

    public static GameState current;
    public PlayerTraits playertraits;

    public GameState()
    {
        playertraits = new PlayerTraits();
    }

}
