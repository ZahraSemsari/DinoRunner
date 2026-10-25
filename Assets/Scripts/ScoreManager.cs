using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    public float scorePerSecond = 10f;

    private float score;
    private int highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
    }

    private void Update()
    {
        score += scorePerSecond * Time.deltaTime;

        int currentScore = Mathf.FloorToInt(score);

        if (currentScore > highScore)
        {
            highScore = currentScore;

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
        highScoreText.text = "High Score: " + highScore;
    }
}