using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletSpeed;
    public PlayerController playerController;
    public PlayerHealth playerHealth;

    public void Shoot()
    {
        if (bulletPrefab == null || shootPoint == null || playerController == null)
        {
            Debug.LogWarning("Faltan referencias en PlayerShooting");
            return;
        }

        // Instanciar la bala
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        // Obtener la direcci�n desde el PlayerController (-1 = izquierda, 1 = derecha)
        int direction = playerController.direction;

        // Aplicar velocidad a la bala seg�n la direcci�n
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(direction * bulletSpeed, 0f);
        }

        // (Opcional) girar la bala si va hacia la izquierda
        if (direction < 0)
        {
            //Vector3 scale = bullet.transform.localScale;
            //scale.x *= -1;
            //bullet.transform.localScale = scale;
        }

        playerHealth.TakeDamage(1);

        // (Opcional) destruir la bala despu�s de un tiempo
        Destroy(bullet, 5f);
    }
}