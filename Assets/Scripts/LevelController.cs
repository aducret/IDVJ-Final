﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelController : MonoBehaviour {
    public Text timerLabel;
    public GameObject deadPanel;
    public GameObject goalPanel;
    public GameObject pausePanel;
    public Text goalTitle;

    private KeyCode pause = KeyCode.P;
    private float totalTime = 0;
    private bool paused = false;

    public bool isPaused()
    {
        return paused;
    }

    void Start()
    {
        goalPanel.SetActive(false);
        deadPanel.SetActive(false);
        pausePanel.SetActive(false);
        unPauseGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(pause))
        {
            if (paused)
            {
                unPauseGame();
            }
            else
            {
                pauseGame(true);
            }
        }

        timeManager();
        if (totalTime < 0)
        {
            lose();
        }
    }

    public void win()
    {
        pauseGame(false);
        setGoalTitle();
        goalPanel.SetActive(true);
    }

    public void lose()
    {
        pauseGame(false);
        deadPanel.SetActive(true);
    }

    public void goToMainMenu()
    {
        goalPanel.SetActive(false);
        deadPanel.SetActive(false);
        pausePanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void goToNextLevel(int level)
    {
        goalPanel.SetActive(false);
        deadPanel.SetActive(false);
        pausePanel.SetActive(false);
        SceneManager.LoadScene("Level " + level);
    }

    private void setGoalTitle()
    {
        var minutes = (int)Mathf.Floor(totalTime / 60);
        var seconds = totalTime % 60;
        goalTitle.text = string.Format("you take {0:00}:{1:00} to complete the level", minutes, seconds);
    }

    private void pauseGame(bool panel)
    {
        Time.timeScale = 0;
        paused = true;
        pausePanel.SetActive(panel);
    }

    public void unPauseGame()
    {
        Time.timeScale = 1;
        paused = false;
        pausePanel.SetActive(false);
    }

    public void resartScene(int level)
    {
        SceneManager.LoadScene("Level " + level);
    }

    private void timeManager()
    {
        totalTime += Time.deltaTime;
        var minutes = (int)Mathf.Floor(totalTime / 60);
        var seconds = totalTime % 60;

        timerLabel.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
