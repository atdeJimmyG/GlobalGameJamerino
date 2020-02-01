using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    /// <summary>
    /// Constructor method for player health.
    /// </summary>
    /// <param name="max"></param>
    public PlayerHealth(int max = 100)
    {
        maxHealth = max;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth > damage)
        {
            currentHealth -= damage;
        } else
        {
            // Player died.
            currentHealth = 0;
            Debug.Log("Player died.");
            return;
        }

        // If damage is negative, then the player will regen.
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        Debug.Log("Health: " + currentHealth);
    }
}
