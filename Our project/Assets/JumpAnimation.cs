using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float jumpForce = 10f;
    private Animator animator;
    private Rigidbody2D rb2D;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Trigger the jump animation
            animator.SetTrigger("JumpTrigger");

            // Call a method to handle the actual jump
            Jump();
        }
    }

    private void Jump()
    {
        // Add code here to apply the jump force or any other jump logic
        // For example, using Rigidbody2D.AddForce:
        rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}