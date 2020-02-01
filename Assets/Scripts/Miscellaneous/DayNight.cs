using System.Collections;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    private int dayLength;   //in minutes
    private int dayStart;
    private int nightStart;   //also in minutes
    private int currentTime;
    public float cycleSpeed;
    public Light sun;
    public GameObject earth;

    void Start()
    {
        dayLength = 1440;
        dayStart = 300;
        nightStart = 1200;
        currentTime = 720;
        StartCoroutine(TimeOfDay());
        earth = gameObject.transform.parent.gameObject;
    }

    void Update()
    {

        if (currentTime > 0 && currentTime < dayStart)
        {
            sun.intensity = 0;
        }
        else if (currentTime >= dayStart && currentTime < nightStart)
        {
            sun.intensity = 1;
        }
        else if (currentTime >= nightStart && currentTime < dayLength)
        {
            sun.intensity = 0;
        }
        else if (currentTime >= dayLength)
        {
            currentTime = 0;
        }
        float currentTimeF = currentTime;
        float dayLengthF = dayLength;
        earth.transform.eulerAngles = new Vector3(0, (-(currentTimeF / dayLengthF) * 360) + 90, 0);

        Collider2D coll = Physics2D.OverlapCircle(GameObject.FindGameObjectWithTag("Bed").transform.position, 20f, 1 << LayerMask.NameToLayer("Player"));
        if (Input.GetKey(KeyCode.E) && coll != null)
        {
            cycleSpeed = 9000;
        }
        else if (!Input.GetKey(KeyCode.E))
        {
            cycleSpeed = 4;
        }
    }

    IEnumerator TimeOfDay()
    {
        while (true)
        {
            currentTime += 1;
            
            yield return new WaitForSeconds(1F / cycleSpeed);
        }
    }

}