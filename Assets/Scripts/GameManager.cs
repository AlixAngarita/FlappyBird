using System.Collections;
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

    //sound
    public AudioSource buttonSound;

    private int finalScore = 0;
    private int bestScore;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        Score.SetActive(false);
        startView.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void StartGame()
    {
        buttonSound.Play();
        startPanel.SetActive(false);
        Score.SetActive(true);
        startView.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(waitForClick());
    }

    private IEnumerator waitForClick()
    {
        bool done = false;
        while(!done) // waits for mouse button down
        {
            if(Input.GetMouseButtonDown(0))
            {
                done = true; // breaks the loop
                Time.timeScale = 1;
                startView.SetActive(false);
            }
            yield return null;
        }
    }

    public void UpdateScore(int points)
    {
        Score scoreScript = Score.GetComponent<Score>();
        scoreScript.score += points;
        finalScore += points;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Score.SetActive(false);
        FinalScore finalScoreScript = FinalScore.GetComponent<FinalScore>();
        finalScoreScript.score = finalScore;
        bestScore = PlayerPrefs.GetInt("Player Best Score");
        if(finalScore > bestScore)
        {
            PlayerPrefs.SetInt("Player Best Score", finalScore);
        } 
        
        buttonSound.Play();
        gameOverPanel.SetActive(true);

        //Best score
        FinalScore bestScoreScript = BestScore.GetComponent<FinalScore>();
        bestScoreScript.score = PlayerPrefs.GetInt("Player Best Score");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
