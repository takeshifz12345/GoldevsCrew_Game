using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public bool canHeal;
    public float healCooldown;
    public float healCooldownTimer;
    public int signaLevel;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged();
    }

    public void Heal()
    {
        if (canHeal)
        {
            currentHealth += signaLevel;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            OnHealthChanged();

            StartHealCooldown();
        }
    }

    public void StartHealCooldown()
    {
        canHeal = false;
        healCooldownTimer = 0f;
    }

    public void UpdateCooldown()
    {
        if (!canHeal)
        {
            healCooldownTimer += Time.deltaTime;

            if (healCooldownTimer >= healCooldown)
            {
                canHeal = true;
                healCooldownTimer = 0f;
            }
        }
    }

    public void OnHealthChanged()
    {
        //Pa´ luego.
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        UpdateCooldown();
    }
}