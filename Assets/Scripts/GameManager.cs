using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject scorePanel;

    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI bestScore;

    private int score;  // We would store user's high score here (in PlayerPref, similar to SharedPreference)

    // Singleton object is initialised in the Awake Function
    private void Awake()
    {
        if (Instance == null)
        { 
            Instance = this;
        }
        Time.timeScale = 1.0f;  // Resume, or Start, Game
        gameOverPanel.SetActive(false);
        scorePanel.SetActive(true);
    }

    private void Start()
    {
        currentScore.text = score.ToString();
        bestScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }

    private void UpdateHighScore() 
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            bestScore.text = score.ToString();
        }
    }

    public void updateMatchScore() 
    {
        score++;
        currentScore.text = score.ToString();
        UpdateHighScore();
    }

    public void GameOver() 
    { 
        gameOverPanel.SetActive(true);
        scorePanel.SetActive(false);
        Time.timeScale = 0f;    // Pauses game, time, everything
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Calling this function will destroy the Singleton objects as well
        // Unless "DontDestroyOnLoad" is called with singleton instance, this will be destroyed
    }
}
