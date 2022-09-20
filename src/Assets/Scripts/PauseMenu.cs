using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool Paused = false;
    public GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Paused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ResumeGame() {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void loadMenu()
    {
        Time.timeScale = 1f;
        Paused = false;
        SceneManager.LoadScene("Menu");
    }

    public void quitGame() {
        Application.Quit();
    }
}
