using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxX = 5f;
    public float minX = -5f;
    bool alive = true;

    public float speed = 5f;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2f;

    public float speedIncreasePerPoint = 0.1f;

    private void FixedUpdate()
    {
        if (!alive) return;

        // Move the player forward along the global z-axis (positive z direction)
        Vector3 forwardMove = Vector3.back * speed * Time.fixedDeltaTime;
        // Horizontal movement based on input
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        
        // Move the player
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        // Get horizontal input from 'A' and 'D' keys
        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = -1f; // Move left
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = 1f; // Move right
        }
        else
        {
            horizontalInput = 0f; // No horizontal movement
        }

        // Check if the player has fallen off the platform
        if (transform.position.y < -5)
        {
            Die();
        }

        // Constrain the player's x position within minX and maxX
        Vector3 playerPos = transform.position;
        if (playerPos.x < minX)
        {
            playerPos.x = minX;
        }
        else if (playerPos.x > maxX)
        {
            playerPos.x = maxX;
        }

        transform.position = playerPos;
    }

    public void Die()
    {
        alive = false;
        // Restart the game after 2 seconds
        Invoke("Restart", 2);
    }

    void Restart()
    {
        // Reload the current scene to restart the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
