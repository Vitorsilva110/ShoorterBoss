
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;

    public Slider healthBar;

    public bool IsInvulnerable { get; private set; }

    public enum LifeState
    {
        High,
        Medium,
        Low
    }

    public LifeState CurrentLifeState { get; private set; }

    void Awake()
    {
        currentHealth = maxHealth;
        UpdateLifeState();

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        if (IsInvulnerable || currentHealth <= 0)
            return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        UpdateLifeState();

        if (healthBar != null)
            healthBar.value = currentHealth;

        Debug.Log("Vida do Boss: " + currentHealth);
        Debug.Log("Nível de vida: " + CurrentLifeState);

        if (currentHealth <= 0)
        {
            if (GameManager.Instance != null)
                GameManager.Instance.WinGame();
            else
                Debug.LogError("GameManager não encontrado!");
        }
    }

    void UpdateLifeState()
    {
        float healthPercentage = (float)currentHealth / maxHealth;

        if (healthPercentage > 0.5f)
            CurrentLifeState = LifeState.High;
        else if (healthPercentage > 0.2f)
            CurrentLifeState = LifeState.Medium;
        else
            CurrentLifeState = LifeState.Low;
    }

    public void SetInvulnerable(bool value)
    {
        IsInvulnerable = value;
    }
}
