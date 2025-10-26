using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyAttack : MonoBehaviour
{
    [Header("Configuración del proyectil")]
    public float speed = 5f;       // Velocidad de movimiento
    public float lifeTime = 3f;    // Tiempo de vida
    public int damage = 1;         // Daño al jugador
    public Vector2 direction = Vector2.right; // Dirección inicial

    private void Awake()
    {
        // Normalizar dirección para evitar valores raros
        direction = direction.normalized;
    }

    private void Update()
    {
        // Movimiento usando Transform (simple, útil para proyectiles rápidos)
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        // Contador de vida
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        var playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth?.TakeDamage(damage);

        Destroy(gameObject);
    }
}