﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject startView;
    public GameObject gameOverPanel;
    public Player player;
    public GameObject Score;
    public GameObject FinalScore;
    public GameObject BestScore;

    public Text gameOverCountdown;
    public float countTimer = 5;
    private int finalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameOverCountdown.gameObject.SetActive(false);
        Time.timeScale = 0;
        Score.SetActive(false);
        startView.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        /*if( player.isDead )
        {
            gameOverCountdown.gameObject.SetActive(true);
            countTimer -= Time.unscaledDeltaTime;
        }

        gameOverCountdown.text = "Restarting in " + (countTimer).ToString("0");

        if(countTimer < 0)
        {
            RestartGame();
        }*/
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        Score.SetActive(true);
        startView.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(waitForClick());
    }

    private IEnumerator waitForClick()
    {
        bool done = false;
        while(!done) // essentially a "while true", but with a bool to break out naturally
        {
            if(Input.GetMouseButtonDown(0))
            {
                done = true; // breaks the loop
                Time.timeScale = 1;
                startView.SetActive(false);
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }
    }

    public void UpdateScore()
    {
        Score scoreScript = Score.GetComponent<Score>();
        scoreScript.score++;
        finalScore++;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Score.SetActive(false);
        FinalScore finalScoreScript = FinalScore.GetComponent<FinalScore>();
        finalScoreScript.score = finalScore;
        gameOverPanel.SetActive(true);

        //Best score
        FinalScore bestScoreScript = BestScore.GetComponent<FinalScore>();
        bestScoreScript.score = finalScore;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}