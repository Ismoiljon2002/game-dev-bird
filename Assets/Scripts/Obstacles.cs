using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed = 2.0f;

    private void FixedUpdate()
    {
        // Move the obstacle to the left
        transform.position += ((Vector3.left * speed) * Time.deltaTime);
    }

    // Detect when the player passes through the obstacle
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.CrossObstacle(); // Notify the player that an obstacle has been crossed
            }
        }
    }
}
