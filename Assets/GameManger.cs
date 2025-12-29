using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeRemaining = 300f; // الـ 5 دقايق
    public TextMeshProUGUI timerText; // نص التايمر اللي على الشاشة
    private bool isGameOver = false;

    void Start()
    {
        Time.timeScale = 1f; // اللعبة تبدأ شغالة
    }

    void Update()
    {
        if (isGameOver) return; // لو خسرنا ميعملش حاجة تانية

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // ينقص الوقت
            UpdateTimerDisplay();
        }
        else
        {
            TriggerLose(); // لو الوقت خلص تخسر
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void TriggerLose()
    {
        isGameOver = true;
        Time.timeScale = 0f; // يوقف حركة كل حاجة في اللعبة
        Cursor.visible = true; // يظهر الماوس
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartBtn() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    public void QuitBtn() { Application.Quit(); }

    public void OnGhostTouchPlayer()
    {
        if (!isGameOver) // نتحقق إننا مخرسناش أصلاً قبل كدة
        {
            TriggerLose();
        }
    }
}
