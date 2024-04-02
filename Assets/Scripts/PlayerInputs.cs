using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private Vector2 _dashDirection;
    [SerializeField] Collisions _collisions;
    [SerializeField] Dash _dash;
    [SerializeField] public GameObject _sight;
    [SerializeField] Glued _glued;
    

    private void Update()
    {
         Vector2 _mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _sight.transform.position = _mouseWorldPosition;
    }
    public void OnDetermineDirection(InputAction.CallbackContext context)
    {
        _sight.transform.position = context.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_collisions.IsGlued)
            {
                _glued.GluedDown = false;
                _glued.GluedUp = false;
                _glued.GluedLeft = false;
                _glued.GluedRight = false;
                _collisions.IsGlued = false;
            }
            _dashDirection = (_sight.transform.position - transform.position).normalized;
            _dash.DashTowards(_dashDirection);
        }
    }
}
