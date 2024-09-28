using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject startBtn;
    public Player birdBek;

    public Text gameOverTxt;
    public float timerBack = 3;

    public AudioClip gameOverSound;
    private AudioSource audioSource;

    private bool isGameOverSoundPlayed = false;

    private void Start()
    {
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
                isGameOverSoundPlayed = true; 
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
