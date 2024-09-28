using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 15.0f;
    private Rigidbody2D rb;
    public bool isDead = false;

    public AudioClip jumpSound; 
    public AudioClip successSound; 
    private AudioSource audioSource; 

    public Text scoreText; 
    private int score = 0; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        audioSource = gameObject.AddComponent<AudioSource>();

        UpdateScoreText();
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && !isDead)
        {
            rb.velocity = Vector2.up * speed;

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

    public void CrossObstacle()
    {
        score++;

        if (successSound != null)
        {
            audioSource.PlayOneShot(successSound);
        }

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
