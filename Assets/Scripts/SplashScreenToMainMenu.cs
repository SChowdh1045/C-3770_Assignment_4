using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Splash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GoToMainMenu", 5f);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
