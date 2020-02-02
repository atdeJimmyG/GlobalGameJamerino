using UnityEngine;

public class Animation : MonoBehaviour
{
    protected enum WalkDirection
    {
        Up,
        Down,
        Left,
        Right,
        Idle
    }

    protected Animator anim;
    
    protected void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow)){
            SetAnimationDirection(WalkDirection.Up);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            SetAnimationDirection(WalkDirection.Down);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            SetAnimationDirection(WalkDirection.Left);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            SetAnimationDirection(WalkDirection.Right);
        }
        else {
            SetAnimationDirection(WalkDirection.Idle);
        }
    }

    protected void SetAnimationDirection(WalkDirection dir)
    {
        switch (dir)
        {
            case (WalkDirection.Up):
                anim.SetBool("isUp", true);
                anim.SetBool("isDown", false);
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", false);
                anim.SetBool("isIdle", false);
                break;
            case (WalkDirection.Down):
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", true);
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", false);
                anim.SetBool("isIdle", false);
                break;
            case (WalkDirection.Left):
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", false);
                anim.SetBool("isLeft", true);
                anim.SetBool("isRight", false);
                anim.SetBool("isIdle", false);
                break;
            case (WalkDirection.Right):
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", false);
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", true);
                anim.SetBool("isIdle", false);
                break;
            case (WalkDirection.Idle):
                anim.SetBool("isUp", false);
                anim.SetBool("isDown", false);
                anim.SetBool("isLeft", false);
                anim.SetBool("isRight", false);
                anim.SetBool("isIdle", true);
                break;
        }
    }
}
