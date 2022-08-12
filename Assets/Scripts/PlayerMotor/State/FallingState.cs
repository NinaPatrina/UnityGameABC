using UnityEngine;

public class FallingState : BaseState
{
    public AudioClip splashSound;
    public override void Construct()
    {
        motor.anim?.SetTrigger("Fall");
        AudioManager.Instance.PlaySFX(splashSound, 0.7f);
    }
    public override Vector3 ProcessMotion()
    {
        motor.ApplyGravity();

        Vector3 m = Vector3.zero;

        m.x = motor.SnapToLane();
        m.y = motor.verticalVelocity;
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
        if (motor.isGrounded)
            motor.ChangeState(GetComponent<WalkingState>());
    }
}
