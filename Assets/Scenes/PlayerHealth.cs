using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currHealth;

    Animator anim;
    bool isDead;
    bool isDamaged;

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
            //Death();
            Debug.Log("Dead");
        }
    }
}
