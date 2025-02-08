using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

public Text finalScoreText;  // Reference to the "Scores" UI Text
    
    int score;
    public static GameManager inst;

    [SerializeField] Text scoreText;

    [SerializeField] PlayerMovement playerMovement;

    public void IncrementScore ()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        // Increase the player's speed
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    private void Awake ()
    {
        inst = this;
    }

    public int GetFinalScore()
    {
        return score;
    }
    public void RetryGame()
{
    // Reload the active scene (this will restart the game)
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}

public void QuitGame()
{
    // Quit the application
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
    #else
    Application.Quit();
    #endif
}

    public void ShowFinalScore()
    {
        int finalScore = GetFinalScore();
        finalScoreText.text = "Your Score: " + finalScore.ToString();
    }

}