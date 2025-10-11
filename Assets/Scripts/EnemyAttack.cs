using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject); // destruir el proyectil o golpe enemigo al impactar
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        // Reducir vida útil con el tiempo
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}