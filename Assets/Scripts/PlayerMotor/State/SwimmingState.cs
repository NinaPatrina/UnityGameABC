
using UnityEngine;

public class SwimmingState : BaseState
{
    //public override void Construct()
    //{
    //    motor.verticalVelocity = 0;
    //}
    public override Vector3 ProcessMotion()
    {
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
        if (InputManager.Instance.Tap)
        {
            motor.ChangeState(GetComponent<BitingState>());
        }
    }
}
