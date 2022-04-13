using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMessagesHandler : PlayerInputActions
{
	private void OnMovement(InputValue value)
    {
		MovementValue = value.Get<Vector2>();
	}

	private void OnLook(InputValue value)
    {
		LookValue = value.Get<Vector2>();
	}

	private void OnJump(InputValue value)
    {
		JumpValue = value.isPressed;
	}

	private void OnSprint(InputValue value)
    {
		SprintValue = value.isPressed;
	}
}
