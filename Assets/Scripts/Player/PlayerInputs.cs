using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private Vector2 _dashDirection;
    [SerializeField] Collisions _collisions;
    [SerializeField] Dash _dash;
    [field: SerializeField] public GameObject _sight { get; private set; }
    [SerializeField] PlayerInput _playerInput;
    bool _isGamepad = false;
    Vector2 _mouseWorldPosition;

    private void Update()
    {
        if (_isGamepad) return;
         _mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _sight.transform.position = _mouseWorldPosition;
    }
    public void OnDetermineDirection(InputAction.CallbackContext context)
    {
        if(_playerInput.currentControlScheme == "Gamepad")
        {
            _isGamepad = true;
            _sight.transform.localPosition = context.ReadValue<Vector2>() * 5;
        }
        else
        {
            _isGamepad = false;
        }
    }

    public void OnRestart(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            GetComponent<Death>().Kill();
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            print(_sight.transform.localPosition);
            _dashDirection = (_sight.transform.position - transform.position).normalized;
            _dash.DashTowards(_dashDirection);
        }
    }
}
