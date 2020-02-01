using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed;
    public float runSpeed;
    public float walkSpeed;

    private Rigidbody2D rb2d;

    public float Stamina;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Stamina = 100f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX,moveY);
        rb2d.AddForce(movement * baseSpeed);


        //Debug.Log(Stamina);
        if (Input.GetKey(KeyCode.LeftShift) && moveX != 0 && moveY != 0) {
            // deplete Stamina at a rate of 5 units per second
            float v = Stamina -= 5f * Time.deltaTime;
            //StaminaGUIBar.size = Stamina / 100f;
        }
        else if (Stamina < 100f) {
            StaminaRegen();
        }
        if(Stamina < 50f) {
            baseSpeed = walkSpeed;
        }
        else {
            baseSpeed = (runSpeed - walkSpeed);
        }
    }

    public void StaminaRegen() {
        Stamina = Mathf.Min(100f, Stamina + 5f * Time.deltaTime);
        //StaminaGUIBar.size = Stamina / 100f;
    }
}
