using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private CircleCollider2D _collider;

    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _force = 0;
    [SerializeField] private float _deltaTime = 0;
    [SerializeField] private float _timeLimit = 10f;
    [SerializeField] private bool _isClick = false;
    [SerializeField] private bool _isGrounded = false;
    [SerializeField] private UnityEvent<float> OnClickEvent;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
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
        if (_isClick)
        {
            _deltaTime += Time.deltaTime;
            OnClickEvent.Invoke(_deltaTime/_timeLimit);
        }

        if (!_isGrounded)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * _collider.radius);
            if (hit.collider != null) _isGrounded = true;
        }
    }

    private void OnButtonDown(InputAction.CallbackContext context)
    {
        if (!_isGrounded) return;
        _isClick = true;
    }

    private void OnButtonUp(InputAction.CallbackContext context)
    {
        if (_deltaTime >= _timeLimit) _deltaTime = _timeLimit;
        _rigidbody.AddForce(_deltaTime * _force * _direction, ForceMode2D.Impulse);
        _deltaTime = 0;
        _isClick = false;
        _isGrounded = false;
    }
}