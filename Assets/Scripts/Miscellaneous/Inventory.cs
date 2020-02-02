using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] Slots;

    public GameObject slot;
    HungerThirst wellbeing;

    public Weapon[] weapons;

    GameObject player;

    void Start()
    {
        wellbeing = GetComponent<HungerThirst>();
        player = GameObject.Find("Player");
    }

    public void OnPickup(GameObject item, int i)
    {

        GameObject newItemSlot = Instantiate(slot, Slots[i].transform.position, Quaternion.identity, GameObject.Find("Hotbar").transform);
        Destroy(Slots[i]);
        newItemSlot.name = "Slot " + i;
        Slots[i] = newItemSlot;
        item.transform.parent = Slots[i].transform;
        item.transform.position = Vector3.zero;
        Slots[i].GetComponentsInChildren<Image>()[1].sprite = item.GetComponent<SpriteRenderer>().sprite;
        Slots[i].GetComponentInChildren<Text>().text = (i+1).ToString();
        Slots[i].GetComponentInChildren<Image>().gameObject.name = item.name;
    }

    void ResetSlot(int slo)
    {
        GameObject newItemSlot = Instantiate(slot, Slots[slo].transform.position, Quaternion.identity, GameObject.Find("Hotbar").transform);
        Destroy(Slots[slo]);
        newItemSlot.name = "Slot " + slot;
        Slots[slo].GetComponentInChildren<Text>().text = (slo + 1).ToString();
        Slots[slo] = newItemSlot;
        isFull[slo] = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItem(Slots[0].name, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseItem(Slots[1].name, 1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseItem(Slots[2].name, 2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UseItem(Slots[3].name, 3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            UseItem(Slots[4].name, 4);
        }
        if(wellbeing.Hunger > 100)
        {
            wellbeing.Hunger = 100;
        }
        if(wellbeing.Thirst > 100)
        {
            wellbeing.Thirst = 100;
        }
    }

    void UseItem(string name, int slot)
    {
        Debug.Log(name);
        if(name == "apple(Clone)")
        {
            wellbeing.Hunger += 25;
            wellbeing.Thirst += 10;
            ResetSlot(slot);
        }
        else if (name == "water(Clone)")
        {
            wellbeing.Thirst += 50;
            ResetSlot(slot);
        }
        else if (name == "beans(Clone)")
        {
            wellbeing.Hunger += 45;
            wellbeing.Thirst += 15;
            ResetSlot(slot);
        }
        else if (name == "medkit(Clone)")
        {
            player.GetComponent<PlayerController>().health.TakeDamage(-75);
            ResetSlot(slot);
        }
        else if (name == "rifle(Clone)")
        {
            foreach(Weapon wep in weapons)
            {
                if(wep.name == "AssaultRifle")
                {
                    player.GetComponentInChildren<PlayerAttack>().EquipWeapon(wep);
                }
            }
        }
        else if(name == "pistol(clone)")
        {
            foreach (Weapon wep in weapons)
            {
                if (wep.name == "Pistol")
                {
                    player.GetComponentInChildren<PlayerAttack>().EquipWeapon(wep);
                }
            }
        }
        else if(name == "bat(clone)")
        {
            foreach (Weapon wep in weapons)
            {
                if (wep.name == "Baseball Bat")
                {
                    player.GetComponentInChildren<PlayerAttack>().EquipWeapon(wep);
                }
            }
        }
        else if (name == "knife1(clone)")
        {
            foreach (Weapon wep in weapons)
            {
                if (wep.name == "Knife1")
                {
                    player.GetComponentInChildren<PlayerAttack>().EquipWeapon(wep);
                }
            }
        }
        else if (name == "knife2(clone)")
        {
            foreach (Weapon wep in weapons)
            {
                if (wep.name == "Knife2")
                {
                    player.GetComponentInChildren<PlayerAttack>().EquipWeapon(wep);
                }
            }
        }
    }
}
