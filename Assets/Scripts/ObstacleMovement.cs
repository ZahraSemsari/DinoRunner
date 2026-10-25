using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float destroyX = -10f;

    private void Update()
    {
        float currentSpeed =
            moveSpeed * PlayerController.WorldSpeedMultiplier;

        transform.Translate(
            Vector2.left * currentSpeed * Time.deltaTime
        );

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}