using JetBrains.Annotations;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public bool canHeal;
    public float healCooldown;
    public float healCooldownTimer;
    public int signaLevel;
    public UIHealth uIHealth;
    public UICooldown uICooldown;
    public UISignal uISignal;

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

            int intCooldown = (int)healCooldownTimer;
            uICooldown.UpdateCooldownUI(intCooldown);
        }
    }

    public void OnHealthChanged()
    {
        uIHealth.UpdateHealthUI(currentHealth);
    }

    public void UpdateSignal(int newSignal)
    {
        signaLevel = newSignal;
        uISignal.UpdateSignalUI(signaLevel);
    }

    void Start()
    {
        currentHealth = maxHealth;
        uIHealth.UpdateHealthUI(currentHealth);
        uICooldown.UpdateCooldownUI(healCooldownTimer);
    }

    void Update()
    {
        UpdateCooldown();
        uIHealth.UpdateHealthUI(currentHealth);
    }
}