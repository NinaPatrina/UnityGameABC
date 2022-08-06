using System;
using System.Linq;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //configuration
    [SerializeField] private float sqrSwipeDeadzone = 50.0f;

    // There shuld be only one InputManager in the scene
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    //action schemes
    private RunnerInputAction actionSheme;

    #region public properties
    public Vector2 TouchPosition { get { return touchPosition; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool Tap { get { return tap; } }
    #endregion

    #region privates
    private Vector2 touchPosition;
    private Vector2 startDrag;
    private bool swipeRight;
    private bool swipeUp;
    private bool swipeLeft;
    private bool swipeDown;
    private bool tap;

    #endregion

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        SetUpControl();
    }
    private void LateUpdate()
    {
        ResetInputs();
    }
    private void ResetInputs()
    {
        tap = false;
        swipeRight = false;
        swipeUp = false;
        swipeLeft = false;
        swipeDown = false;
    }

    private void SetUpControl()
    {
        actionSheme = new RunnerInputAction();

        /*
        bool testFunc(int input)
        {
            return input % 2 == 0;
        }

        var array = new[] { 1, 2, 3 };
        Func<int, bool> filter = input => input % 2 == 0;
        var filtered = array.Where(testFunc);
        /**/

        //register different action
        actionSheme.Gameplay.Tap.performed += ctx => OnTap(ctx);
        actionSheme.Gameplay.TouchPosition.performed += ctx => OnPosition(ctx);
        actionSheme.Gameplay.StartDrag.performed += ctx => OnStartDrag(ctx);
        actionSheme.Gameplay.EndDrag.performed += ctx => OnEndDrag(ctx);

    }

    private void OnEndDrag(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        Vector2 delta =  touchPosition - startDrag;
        float sqrDistance = delta.sqrMagnitude;

        //confirmed swipe
        if (sqrDistance > sqrSwipeDeadzone)
        {
            float x = Mathf.Abs(delta.x);
            float y = Mathf.Abs(delta.y);

            if (x>y) //left or right
            {
                if (delta.x > 0) swipeRight = true;
                else swipeLeft = true;
            }
            else //up or down
            {
                if (delta.y > 0) swipeUp = true;
                else swipeDown = true;
            }
        }
        startDrag = Vector2.zero;
    }
    private void OnStartDrag(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        startDrag = touchPosition ;
    }
    private void OnPosition(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        touchPosition = ctx.ReadValue<Vector2>();
    }
    private void OnTap(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        tap = true;
    }
    public void OnEnable()
    {
        actionSheme.Enable();
    }
    public void OnDisable()
    {
        actionSheme.Disable();
    }
}
