using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMapInputHandler : MonoBehaviour, IPlayerInputActions 
{
    public Vector2 MovementValue {get; set;}

    private void OnMovement(InputValue value)
    {
        MovementValue = value.Get<Vector2>();
    }

}
