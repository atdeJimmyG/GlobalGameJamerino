using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currHealth;

    Animator anim;
    bool isDead;
    bool isDamaged;

    // Start is called before the first frame update
    void Awake()
    {
        //anim = GetComponent<Animator>();
        //playerAudio = GetComponent<AudioSource>();
        currHealth = startingHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int amount) {
        currHealth -= amount;

        if (currHealth <= 0 && !isDead) {
            // ... it should die.
            //Death();
            Debug.Log("Dead");
        }
    }
}
