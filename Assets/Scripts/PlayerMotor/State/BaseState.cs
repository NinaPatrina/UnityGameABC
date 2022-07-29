
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    //as private but children will have access to protected
    protected PlayerMotor motor;

    public virtual void Construct() { }
    public virtual void Destruct() { }
    public virtual void Transition() { }

    private void Awake()
    {
        motor = GetComponent<PlayerMotor>();
    }

    public virtual Vector3 ProcessMotion()
    {
        Debug.Log("ProcessMotion is not implemented " + this.ToString());
        return Vector3.zero;
    }
}
