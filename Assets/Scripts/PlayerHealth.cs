using System;
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
    
    public GameObject GameOver; // Arrastrar el Canvas desde el Inspector
    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        OnHealthChanged();

       if (currentHealth <= 0)
    {
        Die(); // <-- Aquí llamas a Die cuando el jugador muere
    }
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
    private void Die()
    {
         if (GameOver != null)
            GameOver.SetActive(true); // Mostrar canvas de Game Over

        Time.timeScale = 0f; // Pausa el juego si quieres
    }
  

}