using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour
{

    private Inventory inventory;

    void Start()
    {
        inventory = GameObject.Find("HUD").GetComponent<Inventory>();
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < inventory.Slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    inventory.OnPickup(gameObject, i);
                    break;
                }
            }
        }
    }
}
