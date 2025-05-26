using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _force = 0;
    [SerializeField] private float _deltaTime = 0;
    [SerializeField] private bool _isClick = false;
    [SerializeField] private bool _isGrounded = false;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _direction = _direction.normalized;
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

    private void Update()
    {
        if (_isClick) _deltaTime += Time.deltaTime;
    }

    private void OnButtonDown(InputAction.CallbackContext context)
    {
        if (!_isGrounded) return;
        _isClick = true;
    }

    private void OnButtonUp(InputAction.CallbackContext context)
    {
        _rigidbody.AddForce(_deltaTime * _force * _direction, ForceMode2D.Impulse);
        _deltaTime = 0;
        _isClick = false;
        _isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }
}
