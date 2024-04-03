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

    

    private void Update()
    {
         Vector2 _mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //_sight.transform.position = _mouseWorldPosition;
    }
    public void OnDetermineDirection(InputAction.CallbackContext context)
    {
        _sight.transform.localPosition = context.ReadValue<Vector2>() * 5;
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        print("try dash");
        if (context.performed)
        {
            _dashDirection = (_sight.transform.position - transform.position).normalized;
            _dash.DashTowards(_dashDirection);
        }
    }
}
