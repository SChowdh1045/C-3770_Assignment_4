using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToScenes : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("You quit the game.");
        Application.Quit();
    }

    public void LoadL1()
    {
        SceneManager.LoadScene("L1");
    }
}
