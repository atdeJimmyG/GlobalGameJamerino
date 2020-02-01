using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        GetComponent<PatrolingEnemy>().enabled = false;
        GetComponent<EnemyAI>().enabled = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        GetComponent<PatrolingEnemy>().enabled = true;
        GetComponent<EnemyAI>().enabled = false;
    }
}
