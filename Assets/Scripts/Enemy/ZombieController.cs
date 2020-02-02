﻿using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public PlayerHealth health;
    [SerializeField] private int maxHealth = 50;

    private void Start()
    {
        health = new PlayerHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            GetComponent<PatrolingEnemy>().enabled = false;
            GetComponent<EnemyAI>().enabled = true;
            GetComponentInChildren<ZombieAttack>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            GetComponent<PatrolingEnemy>().enabled = true;
            GetComponent<EnemyAI>().enabled = false;
            GetComponentInChildren<ZombieAttack>().enabled = false;
        }
    }
}
