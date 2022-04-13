using UnityEngine;

/// <summary>
/// This is an abstract class but not an interface because
/// it gives us an opportunity to assign it from inspector.
/// </summary>
public abstract class PlayerInputActions : MonoBehaviour
{
	public Vector2 MovementValue { get; protected set; }
	public Vector2 LookValue { get; protected set; }
	public bool JumpValue { get; protected set; }
	public bool SprintValue { get; protected set; }
}
