using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;
    public int direction;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si choca con un enemigo
        if (other.CompareTag("Enemy"))
        {
            EnemyStatus enemy = other.GetComponent<EnemyStatus>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            else
            {
                KingStatus king = other.GetComponent<KingStatus>();

                king.TakeDamage(damage);
            }

                Destroy(gameObject);
        }
        // Si choca con algo que tenga el tag EnemyAttack
        else if (other.CompareTag("EnemyAttack"))
        {
            Destroy(gameObject);
        }
    }
}