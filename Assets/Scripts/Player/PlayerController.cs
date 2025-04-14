using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private InputAction _moveAction;

    private bool _isMoving;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        InputManager.Instance.PlayerActions.Click.performed += OnButtonDown;
        InputManager.Instance.PlayerActions.Click.canceled += OnButtonUp;
    }

    private void OnDisable()
    {
        InputManager.Instance.PlayerActions.Click.performed -= OnButtonDown;
        InputManager.Instance.PlayerActions.Click.canceled -= OnButtonUp;
    }

    private void FixedUpdate()
    {
        if (_isMoving) _rigidbody.AddForce(Vector2.up * 1f, ForceMode2D.Impulse);
    }

    private void OnButtonDown(InputAction.CallbackContext context)
    {
        _isMoving = true;
    }

    private void OnButtonUp(InputAction.CallbackContext context)
    {
        _isMoving = false;
    }
}
