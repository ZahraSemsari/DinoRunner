using UnityEngine;

public class ScoreItem : Interactable
{
    public int scoreValue = 50;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            Interact(other.gameObject);
        }
    }

    public override void Interact(GameObject player)
    {
        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();

        if (scoreManager != null)
        {
            scoreManager.AddScore(scoreValue);
        }

        Destroy(gameObject);
    }
}