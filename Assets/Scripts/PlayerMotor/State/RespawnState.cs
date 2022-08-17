using UnityEngine;
public class RespawnState : BaseState
{
    [SerializeField] private float verticalDistance = 3.0f;
    [SerializeField]  private float immunityTime = 10f;

    private float startTime;

    public GameObject menuUI2;

    public override void Construct()
    {
        startTime = Time.time;
        motor.controller.enabled = false;
        motor.transform.position = new UnityEngine.Vector3(0, verticalDistance, motor.transform.position.z);
        motor.controller.enabled = true;

        motor.verticalVelocity = 0.0f;
        motor.currentLane = 0;
        motor.anim?.SetTrigger("Respawn");

    }
    public override void Destruct()
    {
        if (menuUI2?.activeSelf == false)
        {

        GameManager.Instance.ChangeCamera(GameCamera.Game);
        }
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
        if (motor.isGrounded && (Time.time - startTime)>immunityTime )
            motor.ChangeState(GetComponent<WalkingState>());
        if (InputManager.Instance.SwipeLeft)
            motor.ChangeLane(-1);
        if (InputManager.Instance.SwipeRight)
            motor.ChangeLane(1);
    }


}
