using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    private float timeRemaining = 300;  // Starting time in seconds
    public TextMeshProUGUI timerText; // Reference to TimerText UI
    public TextMeshProUGUI gameOverText; // Reference to GameOverText UI

    private bool timerIsRunning = false;

    void Start()
    {
        // Start the timer
        timerIsRunning = true;

        // Hide game over text at start
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                UpdateTimerDisplay(0);
                GameOver();

            }
        }

        // IMPORTANT: This works even when game is paused
        if (Input.GetKeyDown(KeyCode.R) && Time.timeScale == 0)
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Unpause FIRST
        Time.timeScale = 1;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Debug.Log("Restarting game..."); // Check if this appears in Console
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(0, timeToDisplay); // Don't show negative time

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        // Show Game Over text
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "GAME OVER!";
        }

        // Stop the game
        Time.timeScale = 0;
    }
}