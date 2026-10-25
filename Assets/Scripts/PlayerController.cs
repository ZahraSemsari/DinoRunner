using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 7f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.15f;
    public LayerMask groundLayer;

    public float dashMultiplier = 1.8f;
    public float dashDuration = 0.35f;

    public static float WorldSpeedMultiplier { get; private set; } = 1f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool isDashing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }

    public void OnDash(InputValue value)
    {
        if (value.isPressed && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;

        WorldSpeedMultiplier = dashMultiplier;

        yield return new WaitForSeconds(dashDuration);

        WorldSpeedMultiplier = 1f;

        isDashing = false;
    }

    private void OnDisable()
    {
        WorldSpeedMultiplier = 1f;
    }
}