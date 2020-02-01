using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExit : MonoBehaviour
{
    private bool show = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        show = !show;
        Debug.Log(show);
        gameObject.transform.GetChild(0).gameObject.SetActive(show);
        gameObject.transform.GetChild(1).gameObject.SetActive(!show);
        //SpriteRenderer.color = new Color(1f, 1f, 1f, 0f)
    }
}
