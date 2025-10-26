using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    public void Shoot(int direction)
    {
        if (bulletPrefab == null) return;

        Vector2 shootPoint = new Vector2(transform.position.x + direction, transform.position.y);

        GameObject bullet = Instantiate(bulletPrefab, shootPoint, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
            rb.linearVelocity = new Vector2(direction * bulletSpeed, 0f);

        Destroy(bullet, 5f);
    }
}