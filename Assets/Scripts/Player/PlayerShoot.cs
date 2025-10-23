using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public PlayerController playerController;
    public PlayerHealth playerHealth;

    public void Shoot()
    {
        if (bulletPrefab == null || playerController == null)
        {
            return;
        }

        // Obtener la direcci�n desde el PlayerController (-1 = izquierda, 1 = derecha)
        int direction = playerController.ultDirection;


        Vector2 shootPoint = new Vector2(transform.position.x + (1 * direction), transform.position.y);

        // Instanciar la bala
        GameObject bullet = Instantiate(bulletPrefab, shootPoint, Quaternion.identity);

        // Aplicar velocidad a la bala seg�n la direcci�n
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(direction * bulletSpeed, 0f);
        }

        playerHealth.TakeDamage(1);

        // (Opcional) destruir la bala despu�s de un tiempo
        Destroy(bullet, 5f);
    }
}