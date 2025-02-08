using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerScript;   // Reference to the PlayerScript to disable player movement
    
    public GameManager score;
    
               // Reference to the ScoreScript to manage the score
    public GameObject gameOverPanel;    // Reference to the Game Over Panel
    

    private void Start()
    {
        // Ensure the game over panel is hidden at the start
        gameOverPanel.SetActive(false);
    }

    

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "obstacles")
        {
            playerScript.enabled = false;   // Disable the PlayerScript to stop movement
            gameOverPanel.SetActive(true);  // Show the Game Over Panel
            score.ShowFinalScore(); // Display final score using the GameOverScript
        }
    }
}
