
using UnityEngine;

public class Animation : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow)){
            anim.SetBool("isLeft", false);
            anim.SetBool("isUp", true);
            anim.SetBool("isRight", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isIdle", false);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            anim.SetBool("isLeft", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isRight", true);
            anim.SetBool("isDown", false);
            anim.SetBool("isIdle", false);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            anim.SetBool("isLeft", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isDown", true);
            anim.SetBool("isIdle", false);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            anim.SetBool("isLeft", true);
            anim.SetBool("isUp", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isIdle", false);
        }
        else {
            anim.SetBool("isIdle", true);
            anim.SetBool("isLeft", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isDown", false);
        }
    }
}
