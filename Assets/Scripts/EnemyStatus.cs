using TMPro;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public TextMeshProUGUI hpText;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        hpText.text = currentHealth.ToString();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        currentHealth = maxHealth;
        hpText.text = currentHealth.ToString();
    }
}