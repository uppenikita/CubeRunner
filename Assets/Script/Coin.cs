using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    [SerializeField] float turnSpeed = 90f;

    private void Start () {
        // Slightly lift the coin to prevent it from getting stuck in the ground or obstacles
        transform.position += Vector3.up * 0.5f;  
    }

    private void OnTriggerEnter (Collider other)
    {
        // If the object collided with is an obstacle, destroy the coin
        if (other.gameObject.GetComponent<Obstacle>() != null) {
            Destroy(gameObject);
            return;
        }

        // Check if the object we collided with is not the player
        if (other.gameObject.name != "Player") {
            return;
        }

        // Add to the player's score
        GameManager.inst.IncrementScore();

        // Destroy this coin object after it has been collected
        Destroy(gameObject);
    }

    private void Update () {
        // Rotate the coin for visual effect
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
