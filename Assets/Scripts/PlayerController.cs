using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool isGrounded;
    public int direction;
    public Rigidbody2D rb;

    public void Move(float direction)
    {
        this.direction = (int)direction;

        // Mover el personaje en el eje X (sin rotación ni cambio de escala)
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
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

    }

    void Update()
    {
         // Leer el eje horizontal (-1 = izquierda, 1 = derecha)
        //float moveInput = Input.GetAxisRaw("Horizontal");

        // Llamar al método de movimiento
       // Move(moveInput);

        // // Salto
        // if (Input.GetButtonDown("Jump") && isGrounded)
        //{
         //   Jump();
       // }
               // Leer el eje horizontal (-1 = izquierda, 1 = derecha)
        //float moveInput = Input.GetAxisRaw("Horizontal");

        //// Mover personaje
        //Move(moveInput);

        //// Salto con la tecla W
        //if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        //{
        //    Jump();
        //}



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