using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Required for using Text UI elements

public class Player : MonoBehaviour
{
    public float speed = 15.0f; // Control the jump speed
    private Rigidbody2D rb;
    public bool isDead = false;

    public AudioClip jumpSound; // Reference to the jump sound effect
    public AudioClip successSound; // Reference to the success sound effect
    private AudioSource audioSource; // Reference to the AudioSource

    public Text scoreText; // Reference to the Text component
    private int score = 0; // Counter for obstacles crossed

    void Start()
    {
        // Get Rigidbody2D Component of the bird
        rb = GetComponent<Rigidbody2D>();

        // Add and initialize the AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();

        // Initialize the score text
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for both mouse click (left button) and space bar press
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !isDead)
        {
            rb.velocity = Vector2.up * speed;

            // Play the jump sound
            if (jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isDead = true;
    }

    // This method will be called when the bird crosses an obstacle
    public void CrossObstacle()
    {
        // Increment the score
        score++;

        // Play the success sound
        if (successSound != null)
        {
            audioSource.PlayOneShot(successSound);
        }

        // Update the score text
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
