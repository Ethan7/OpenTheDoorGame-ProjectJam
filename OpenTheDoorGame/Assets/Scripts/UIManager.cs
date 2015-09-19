using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	

    public void StartGame()
    {
        Application.LoadLevel("Starting room");
    }

    public void ReturnToMenu()
    {
        Application.LoadLevel("mainmenu");
    }

    public void Instructions()
    {
        Application.LoadLevel("instructionsmenu");
    }
}
