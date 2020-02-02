using UnityEngine;

public class ZombieAnimation : Animation
{
    private Vector2 prevPos = Vector2.zero;
    private Vector2 currPos = Vector2.zero;
    private void Update()
    {
        currPos = transform.position;
        Vector2 currDir = (currPos - prevPos).normalized;
        
        if (Mathf.Abs(currDir.x) > Mathf.Abs(currDir.y))
        {
            if (currDir.x < 0)
            {
                SetAnimationDirection(WalkDirection.Left);
            }
            else if (currDir.x > 0)
            {
                SetAnimationDirection(WalkDirection.Right);
            }
        }
        else
        {
            if (currDir.y > 0) {
                SetAnimationDirection(WalkDirection.Up);
            }
            else if (currDir.y < 0) {
                SetAnimationDirection(WalkDirection.Down);
            }
            else {
                SetAnimationDirection(WalkDirection.Idle);
            }
        }

        prevPos = currPos;
    }
}
