﻿using UnityEngine;

public class PatrolingEnemy : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    private Transform[] moveSpots;
    private int randomSpot;

    private void Start()
    {
        GameObject[] MovePoints = GameObject.FindGameObjectsWithTag("MovePoints");
        moveSpots = new Transform[MovePoints.Length];
        for (int i = 0; i < MovePoints.Length; i++)
        {
            moveSpots[i] = MovePoints[i].gameObject.transform;
        }

        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;  
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
