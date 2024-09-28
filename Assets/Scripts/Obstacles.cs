using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed = 2.0f;

    private void FixedUpdate()
    {
        transform.position += ((Vector3.left * speed) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.CrossObstacle(); 
            }
        }
    }
}
