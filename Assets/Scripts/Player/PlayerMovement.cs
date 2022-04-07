using UnityEngine;

[RequireComponent(typeof(IPlayerInputActions))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private IPlayerInputActions _playerInput;

    private void Awake() => InitializeComponents();
    private void InitializeComponents()
    {
        _playerInput = GetComponent<IPlayerInputActions>();
    }

    private void Update() => HandleMovement();
    private void HandleMovement()
    {
        var input = new Vector3(_playerInput.MovementValue.x, 0f, _playerInput.MovementValue.y); 
        transform.position += input * speed * Time.deltaTime;
    }
}
