using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;

    [Header("Estado")]
    public bool isGrounded;
    public int direction;
    public int ultDirection;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move(float dir)
    {
        Debug.Log(Time.timeScale);
        direction = (int)dir;

        Vector2 currentVel = rb.linearVelocity;
        rb.linearVelocity = new Vector2(dir * moveSpeed, currentVel.y);

        bool isWalking = dir != 0;
        animator.SetBool("isWalk", isWalking);

        if (dir < 0)
        {
            spriteRenderer.flipX = true;
            ultDirection = -1;
        }
        else if (dir > 0)
        {
            spriteRenderer.flipX = false;
            ultDirection = 1;
        }
    }

    public void Jump()
    {
        if (!isGrounded) return;

        Vector2 vel = rb.linearVelocity;
        vel.y = 0f; // reset vertical velocity before jump
        rb.linearVelocity = vel;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
}