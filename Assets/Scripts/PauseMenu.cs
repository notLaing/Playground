using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CURRENTLY ATTACHED TO: Canvas_TimeUI
public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject controlsMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        //controlsMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void Resume()
    {
        //controlsMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    /*
    public void Controls()
    {
        controlsMenu.SetActive(true);
    }

    public void OutOfControls()
    {
        controlsMenu.SetActive(false);
    }

    public void Restart()
    {
        GameManagerScript.score = GameManagerScript.stageScore;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        gamePaused = false;

        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().RestartLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }*/
}
