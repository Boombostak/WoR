using UnityEngine;
using System.Collections;

public class MainMenuUI : MonoBehaviour {

    public void NewGame()
    {
        GameState.current = new GameState();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        SaveLoad.Load();
    }

    public void Options()
    {
        
    }
}
