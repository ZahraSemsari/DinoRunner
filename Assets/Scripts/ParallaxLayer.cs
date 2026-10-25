using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float moveSpeed = 0.5f;

    private float width;

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        width = spriteRenderer.bounds.size.x;
    }

    private void Update()
    {
        float currentSpeed =
            moveSpeed * PlayerController.WorldSpeedMultiplier;

        transform.Translate(
            Vector3.left * currentSpeed * Time.deltaTime
        );

        if (transform.position.x <= -width)
        {
            transform.position += Vector3.right * width * 2f;
        }
    }
}