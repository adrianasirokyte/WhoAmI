using UnityEngine;
using UnityEngine.UI;

public class FightHealth : MonoBehaviour {
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthBar;

    private void Start() {
        currentHealth = maxHealth;

        if (healthBar != null) {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
            healthBar.value = currentHealth;
    }
}