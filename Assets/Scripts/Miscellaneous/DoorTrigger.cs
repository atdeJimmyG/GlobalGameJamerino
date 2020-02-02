using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private bool show = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        show = !show;
        gameObject.transform.GetChild(0).gameObject.SetActive(show);
        gameObject.transform.GetChild(1).gameObject.SetActive(!show);
    }
}
