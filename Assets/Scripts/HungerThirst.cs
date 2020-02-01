using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerThirst : MonoBehaviour
{
    public float Hunger;
    public float HungerReductRate;
    public Slider HungerBar;
    public float Thirst;
    public float ThirstReductRate;
    public Slider ThirstBar;


    void Start()
    {
        while (Hunger > 0)
        {
            InvokeRepeating("HungerReduction", 1.0f, 1.0f);
        }

        while (Thirst > 0)
        {
            InvokeRepeating("ThirstReduction", 1.0f, 1.0f);
        }

    }

    void HungerThirstReduction()
    {
        Debug.Log("Work");
        Hunger -= HungerReductRate;
        HungerBar.value = (Hunger);
    }
    void ThirstReduction()
    {
        Debug.Log("Work");
        Thirst -= ThirstReductRate;
        ThirstBar.value = (Thirst);
    }
}
