using UnityEngine;
using UnityEngine.InputSystem;

public class TestController : MonoBehaviour
{
    public void OnMove(InputValue value)
    {
        //Debug.Log($"On Move {value.Get<Vector2>()}");
    }

    public void OnFire(InputValue value)
    {
        Debug.Log($"On Fire {value.isPressed}");
    }
    
    public void OnAxis(InputValue value)
    {
        Debug.Log($"On Axis {value.Get<float>()}");
    }
}