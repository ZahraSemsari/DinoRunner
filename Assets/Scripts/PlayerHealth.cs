using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;

    public Slider healthBar;
    public GameObject gameOverPanel;
    public GameObject pauseButton;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private int currentLives;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        currentLives = maxLives;

        if (healthBar != null)
        {
            healthBar.maxValue = maxLives;
            healthBar.value = currentLives;
        }

        UpdateHearts();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (pauseButton != null)
        {
            pauseButton.SetActive(true);
        }
    }

    public void TakeDamage()
    {
        currentLives--;

        if (currentLives < 0)
        {
            currentLives = 0;
        }

        if (healthBar != null)
        {
            healthBar.value = currentLives;
        }

        UpdateHearts();

        Debug.Log("Lives: " + currentLives);

        if (currentLives <= 0)
        {
            GameOver();
        }
        else
        {
            animator.SetTrigger("Hit");
        }
    }

    private void UpdateHearts()
    {
        if (heart1 != null)
            heart1.SetActive(currentLives >= 1);

        if (heart2 != null)
            heart2.SetActive(currentLives >= 2);

        if (heart3 != null)
            heart3.SetActive(currentLives >= 3);
    }

    private void GameOver()
    {
        StartCoroutine(GameOverSequence());
    }

    private IEnumerator GameOverSequence()
    {
        Debug.Log("Game Over");

        animator.SetTrigger("Death");

        yield return new WaitForSeconds(1f);

        if (pauseButton != null)
        {
            pauseButton.SetActive(false);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
}