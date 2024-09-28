using UnityEngine;
using UnityEngine.SceneManagement; // Use SceneManager instead of EditorSceneManager
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject startBtn;
    public Player birdBek;

    public Text gameOverTxt;
    public float timerBack = 3;

    public AudioClip gameOverSound; // Reference for the game over sound
    private AudioSource audioSource; // Reference to AudioSource

    private bool isGameOverSoundPlayed = false; // Flag to ensure the sound plays only once

    private void Start()
    {
        // Initialize the AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();

        gameOverTxt.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (birdBek.isDead)
        {
            if (gameOverSound != null && !isGameOverSoundPlayed)
            {
                audioSource.PlayOneShot(gameOverSound);
                isGameOverSoundPlayed = true; // Ensure the sound only plays once
            }

            gameOverTxt.gameObject.SetActive(true);
            timerBack -= Time.unscaledDeltaTime;
            gameOverTxt.text = "Restarting in " + (timerBack).ToString("0");

            if (timerBack < 0)
            {
                RestartGame();
            }
        }
    }

    public void StartGame()
    {
        startBtn.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }
}
