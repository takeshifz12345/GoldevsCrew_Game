using TMPro;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [Header("Configuración de vida")]
    public int maxHealth = 10;
    public int currentHealth;

    [SerializeField] private TextMeshProUGUI hpText;

    [Header("Estado")]
    public bool active = false;

    private void Awake()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    /// <summary>
    /// Aplica daño al enemigo si está activo
    /// </summary>
    public void TakeDamage(int damage)
    {
        if (!active) return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        UpdateUI();

        if (currentHealth <= 0)
            Die();
    }

    /// <summary>
    /// Actualiza el texto de vida
    /// </summary>
    private void UpdateUI()
    {
        if (hpText != null)
            hpText.text = currentHealth.ToString();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}