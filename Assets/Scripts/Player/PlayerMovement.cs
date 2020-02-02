using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerHealth health;
    public float baseSpeed;
    public float runSpeed;
    public float walkSpeed;
    public float currentSpeed;

    private HungerThirst PlayerHunger;

    private Rigidbody2D rb2d;

    public float Stamina;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        PlayerHunger = GameObject.Find("HUD").GetComponent<HungerThirst>();
        Stamina = 100f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX,moveY);
        rb2d.velocity = movement * currentSpeed * Time.deltaTime;


        //Debug.Log(Stamina);
        if (Input.GetKey(KeyCode.LeftShift) && (moveX != 0 || moveY != 0)) {
            currentSpeed = runSpeed;

            // deplete Stamina at a rate of 5 units per second
            float v = Stamina -= 5f * Time.deltaTime;
            //StaminaGUIBar.size = Stamina / 100f;
        }
        else if (Stamina < 100f && PlayerHunger.Hunger > 20f) {
            StaminaRegen();
        }
        if(Stamina < 50f) {
            currentSpeed = walkSpeed;
        }
        else if(!Input.GetKey(KeyCode.LeftShift)){
            currentSpeed = baseSpeed;
        }
    }

    public void StaminaRegen() {
        Stamina = Mathf.Min(100f, Stamina + 5f * Time.deltaTime);
        //StaminaGUIBar.size = Stamina / 100f;
    }
}
