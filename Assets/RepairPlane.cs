using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPlane : MonoBehaviour
{

    bool repairing;
    float repairingForTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (repairing)
        {
            repairingForTime += Time.deltaTime;
        }
        else
        {
            repairingForTime = 0;
        }

        if(repairingForTime > 2)
        {

        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                repairing = true;
            }
        }
    }

}
