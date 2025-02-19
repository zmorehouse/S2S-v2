using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int score;
    private int highScore;
    
    public TextMeshProUGUI scoreText; // UI element to display the score

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighScore(); // Load the high score when the game starts
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText(); // Ensure the UI is updated at the start
        LoadHighScore();
        PlayerPrefs.SetInt("CurrentScore", 0);
    }

    // Method to re-link the score UI if it's unlinked after scene changes
    public void SetScoreText(TextMeshProUGUI newScoreText)
    {
        scoreText = newScoreText;
        UpdateScoreText(); // Update the text after re-linking
    }

    public void IncrementScore()
    {
        score++;
        UpdateScoreText(); // Update UI after incrementing score
        PlayerPrefs.SetInt("CurrentScore", score);
        CheckAndUpdateHighScore();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText(); // Update UI after resetting score
        PlayerPrefs.SetInt("CurrentScore", score);

    }

    public int GetScore()
    {
        return score;
    }

    public void CheckAndUpdateHighScore()
    {
        if (score > highScore) // Check if the current score is higher than the high score and replace it if it is
        {
            highScore = score;
            SaveHighScore(); 
        }
    }

    public int GetHighScore()
    {
        return highScore;
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0); // Default to 0 if no high score is found
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Days Employed: {score}";
        }
    }
}
