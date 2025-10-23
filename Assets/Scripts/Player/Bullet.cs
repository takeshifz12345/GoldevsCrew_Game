using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;
    public int direction;

    public void Initialize(int dir)
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si choca con un enemigo
        if (other.CompareTag("Enemy"))
        {
            // Busca si el objeto tiene un componente EnemyStatus
            EnemyStatus enemy = other.GetComponent<EnemyStatus>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
        // Si choca con algo que tenga el tag EnemyAttack
        else if (other.CompareTag("EnemyAttack"))
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}