using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    private HungerThirst PlayerThirst;
    private PlayerHealth playerHealth;

    public Slider Healthbarslider;
    // Start is called before the first frame update
    void Start()
    {
        PlayerThirst = GameObject.Find("HUD").GetComponent<HungerThirst>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

        InvokeRepeating("DyingofThirst", 1.0f, 1.0f);
    }

    void DyingofThirst()
    {
        if (PlayerThirst.Thirst < 20)
        {
            playerHealth.currentHealth -= 1;
            Debug.Log("Player is dying of thirst");
        }
        Healthbarslider.value = (playerHealth.currentHealth);
    }
}
