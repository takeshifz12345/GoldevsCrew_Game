using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool isGrounded;
    public int direction;
    public int ultDirection;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public void Move(float direction)
    {
        this.direction = (int)direction;

        // Movimiento horizontal
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

        bool isWalking = direction != 0;
        animator.SetBool("isWalk", isWalking);

        if (direction == -1)
        {
            spriteRenderer.flipX = true;
            ultDirection = -1;
        }
        else if (direction == 1)
        {
            spriteRenderer.flipX = false;
            ultDirection = 1;
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void Start()
    {
        // Obtiene el Rigidbody2D del personaje
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detecta si el objeto tocado tiene la etiqueta "floor"
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
}