﻿using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused=false;
    public GameObject pauseMenuUI;
    public TextMeshProUGUI pressStart;
    private bool startScreen;

    private void Start()
    {
        pressStart.gameObject.SetActive(true);
        startScreen = true;
        Time.timeScale = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && startScreen)
        {
            pressStart.gameObject.SetActive(false);
            Time.timeScale = 1f;
            startScreen = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("First Demo");
        GameIsPaused = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");

    }
}
