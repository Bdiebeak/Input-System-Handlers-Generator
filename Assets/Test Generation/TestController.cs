using UnityEngine;
using UnityEngine.InputSystem;

public class TestController : MonoBehaviour
{
    public void OnAnalog(InputValue value)
    {
        //Debug.Log($"On Analog {value.Get<float>()}");
    }
    
    public void OnAxis(InputValue value)
    {
        Debug.Log($"On Axis {value.Get<float>()}");
    }
    
    public void OnButton(InputValue value)
    {
        //Debug.Log($"On Button {value.isPressed}");
    }

    public void OnDigital(InputValue value)
    {
        //Debug.Log($"On Digital {value.Get<int>()}");
    }
    
    public void OnDpad(InputValue value)
    {
        //Debug.Log($"On Dpad {value.Get<Vector2>()}");
    }
    
    public void OnInteger(InputValue value)
    {
        //Debug.Log($"On Integer {value.Get<int>()}");
    }
    
    public void OnQuaternion(InputValue value)
    {
        Debug.Log($"On Quaternion {value.Get<Quaternion>()}");
    }
    
    public void OnStick(InputValue value)
    {
        //Debug.Log($"On Stick {value.Get<Vector2>()}");
    }
    
    public void OnVector2(InputValue value)
    {
        //Debug.Log($"On OnVector2 {value.Get<Vector2>()}");
    }
    
    public void OnVector3(InputValue value)
    {
        Debug.Log($"On Vector3 {value.Get<Vector3>()}");
    }
}