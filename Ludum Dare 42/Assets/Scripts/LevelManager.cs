using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void loadLevel(string name)
    {
        Debug.Log("Load Level Request for: " + name);
        SceneManager.LoadScene(name);

    }

	
    public void quitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitGame();
        }
    }


}
