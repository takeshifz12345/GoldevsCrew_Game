using TMPro;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [Header("Configuración de vida")]
    public int maxHealth = 10;
    public int currentHealth;

    public UIEnemyLife uIEnemyLife;

    [Header("Estado")]
    private bool active = false;

    private void Awake()
    {
        currentHealth = maxHealth;
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
        if (uIEnemyLife != null)
            uIEnemyLife.UpdateLifeUI(currentHealth);
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void Active()
    {
        active = true;
        UpdateUI();
    }

    public void SetActive(bool value)
    {
        active = value;
    }
}