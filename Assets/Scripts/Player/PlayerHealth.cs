using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Salud")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Curación")]
    public bool canHeal = true;
    public float healCooldown = 5f;
    public float healCooldownTimer;
    public int signaLevel = 10;

    [Header("UI")]
    public UIHealth uIHealth;
    public UICooldown uICooldown;
    public UISignal uISignal;

    [Header("Referencias")]
    public GameObject GameOver;

    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();

        uIHealth?.UpdateHealthUI(currentHealth);
        uICooldown?.UpdateCooldownUI(healCooldownTimer);
    }

    void Update()
    {
        UpdateCooldown();
        uIHealth?.UpdateHealthUI(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        uIHealth?.UpdateHealthUI(currentHealth);

        if (currentHealth <= 0) Die();
    }

    public void Heal()
    {
        if (!canHeal) return;

        currentHealth = Mathf.Clamp(currentHealth + signaLevel, 0, maxHealth);
        animator?.SetTrigger("isCall");
        uIHealth?.UpdateHealthUI(currentHealth);

        StartHealCooldown();
    }

    private void StartHealCooldown()
    {
        canHeal = false;
        healCooldownTimer = 0f;
    }

    private void UpdateCooldown()
    {
        if (!canHeal)
        {
            healCooldownTimer += Time.deltaTime;

            if (healCooldownTimer >= healCooldown)
            {
                canHeal = true;
                healCooldownTimer = 0f;
            }

            uICooldown?.UpdateCooldownUI((int)healCooldownTimer);
        }
    }

    public void UpdateSignal(int newSignal)
    {
        signaLevel = newSignal;
        uISignal.UpdateSignalUI(signaLevel);
    }

    private void Die()
    {
        if (GameOver != null)
            GameOver.SetActive(true);

        Time.timeScale = 0f;
    }
}