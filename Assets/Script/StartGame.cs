using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TapToStart : MonoBehaviour
{
    public Text startText;  // Reference to the "Tap to Start" text
    public Canvas canvas;  // Reference to the Canvas (set this in the Inspector)

    private void Start()
    {
        // Ensure the game is paused at the start
        Time.timeScale = 0f;
    }

    private void Update()
    {
        // Check for mouse click or touch input
        if (Input.GetMouseButtonDown(0))
        {
            // Detect if the click is on the "Tap to Start" text
            Vector2 clickPosition = Input.mousePosition;
            RectTransform rectTransform = startText.GetComponent<RectTransform>();

            // Convert screen point to world point in the context of the canvas
            Vector2 localPoint;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, clickPosition, Camera.main, out localPoint))
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, clickPosition))
                {
                    // Start the game
                    StartGame();
                }
            }
        }
    }

    void StartGame()
    {
        // Unpause the game and hide the start text
        Time.timeScale = 1f;
        startText.gameObject.SetActive(false);
    }
}
