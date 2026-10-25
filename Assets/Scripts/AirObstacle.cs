using UnityEngine;

public class AirObstacle : Interactable
{
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
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage();
        }
    }
}