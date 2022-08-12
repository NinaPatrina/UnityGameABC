
using UnityEngine;

public class WalkingState : BaseState
{
    public override void Construct()
    {
        motor.verticalVelocity = 0;
        motor.anim?.SetTrigger("Walk");
    }
    public override Vector3 ProcessMotion()
    {
        motor.ApplyGravity();

        Vector3 m = Vector3.zero;

        m.x = motor.SnapToLane();
        m.y = -1.0f;
        m.z = motor.baseRunSpeed;
        return m;

    }
    public override void Transition()
    {
        if (InputManager.Instance.SwipeLeft)
        {
            motor.ChangeLane(-1);
        }
        if (InputManager.Instance.SwipeRight)
        {
            motor.ChangeLane(1);
        }
        if (InputManager.Instance.SwipeUp && motor.isGrounded)
        {
            motor.ChangeState(GetComponent<JumpingState>());
        }
        if (!motor.isGrounded)
            motor.ChangeState(GetComponent<FallingState>());
       
    }
}
