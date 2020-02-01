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
        InvokeRepeating("HungerReduction", 1.0f, 1.0f);

        InvokeRepeating("ThirstReduction", 1.0f, 1.0f);
    }

    void HungerReduction()
    {
        if (Hunger <= 0)
        {
            return;
        }
        Debug.Log("Work");
        Hunger -= HungerReductRate;
        HungerBar.value = (Hunger);
    }
    void ThirstReduction()
    {
        if (Thirst <= 0)
        {
            return;
        }
        Debug.Log("Work");
        Thirst -= ThirstReductRate;
        ThirstBar.value = (Thirst);
    }
}
