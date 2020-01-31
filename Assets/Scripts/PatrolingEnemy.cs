using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolingEnemy : MonoBehaviour
{
    public float Speed;
    private float WaitTime;
    public float StartWaitTime;

    private Transform[] MoveSpots;
    private int RandomSpot;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] MovePoints = GameObject.FindGameObjectsWithTag("MovePoints");
        MoveSpots = new Transform[MovePoints.Length];
        for (int i = 0; i < MovePoints.Length; i++)
        {
            MoveSpots[i] = MovePoints[i].gameObject.transform;
        }

        WaitTime = StartWaitTime;
        RandomSpot = Random.Range(0, MoveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, MoveSpots[RandomSpot].position, Speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, MoveSpots[RandomSpot].position) < 0.2f)
        {
            if (WaitTime <= 0)
            {
                RandomSpot = Random.Range(0, MoveSpots.Length);
                WaitTime = StartWaitTime;  
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }
    }
}
