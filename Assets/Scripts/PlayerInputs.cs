using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private Vector2 _dashDirection;
    [SerializeField] Collisions _collisions;
    [SerializeField] Dash _dash;
    [SerializeField] public GameObject _sight;
    [SerializeField] PlayerInput _playerInput;
    Vector2 _mouseWorldPosition;

    private void Update()
    {
         _mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //_sight.transform.position = _mouseWorldPosition;
    }
    public void OnDetermineDirection(InputAction.CallbackContext context)
    {
        if(_playerInput.currentControlScheme == "gamepad")
        {
            _sight.transform.localPosition = context.ReadValue<Vector2>() * 5;
        }
        else
        {
            _sight.transform.position = _mouseWorldPosition;
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _dashDirection = (_sight.transform.position - transform.position).normalized;
            _dash.DashTowards(_dashDirection);
        }
    }
}
