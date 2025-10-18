using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float speed = 5f;       // Velocidad de movimiento
    public float lifeTime = 3f;    // Tiempo de vida
    public int damage = 10;        // Da�o al jugador
    public Vector2 direction;      // Direcci�n de movimiento (-1,0 izquierda / 1,0 derecha / 0,1 arriba etc.)

    void Start()
    {
        // Normalizar direcci�n por si se pasa alg�n valor chueco
        direction = direction.normalized;
    }

    void Update()
    {
        // Movimiento
        transform.Translate(direction * speed * Time.deltaTime);

        // Tiempo de vida
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject); // Destruir proyectil tras impacto
        }
    }
}