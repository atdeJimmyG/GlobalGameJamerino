using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    private HungerThirst PlayerThirst;

    public Slider Healthbar;


    void Start()
    {
        PlayerThirst = GameObject.Find("HUD").GetComponent<HungerThirst>();

        InvokeRepeating("DyingofThirst", 1.0f, 1.0f);
    }


    void DyingofThirst()
    {
        if (PlayerThirst.Thirst < 20)
        {
            currentHealth -= 1;
            Debug.Log("Player is dying of thirst");
        }
        Healthbar.value = (currentHealth);
    }

    /// <summary>
    /// Constructor method for player health.
    /// </summary>
    /// <param name="max"></param>
    public PlayerHealth(int max = 100)
    {
        maxHealth = max;
        currentHealth = maxHealth;
        if (currentHealth <= 0)
        {
            return;
        }
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
