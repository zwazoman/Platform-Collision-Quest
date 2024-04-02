using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    private Vector2 _dashDirection;
    [SerializeField] private Dash _dash;
    [SerializeField] GameObject _sight;
    private  Vector3 _mouseWorldPosition;
    float rayLength = 0.19f;
    public LayerMask layerMask;
    private void Awake()
    {
        _mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mouseWorldPosition.z = 0;
    }
    private void Update()
    {
        _sight.transform.position = _mouseWorldPosition;
        if (Physics2D.Raycast(transform.position, Vector2.down, rayLength, layerMask.value) && mouseWorldPosition.y < transform.position.y)
        {
            print("nope");
            return;
        }
        if (Physics2D.Raycast(transform.position, Vector2.up, rayLength, layerMask.value) && mouseWorldPosition.y > transform.position.y)
        {
            print("nope");
            return;
        }
        if (Physics2D.Raycast(transform.position, Vector2.left, rayLength, layerMask.value) && mouseWorldPosition.x < transform.position.x)
        {
            print("nope");
            return;
        }
        if (Physics2D.Raycast(transform.position, Vector2.right, rayLength, layerMask.value) && mouseWorldPosition.x > transform.position.x)
        {
            print("nope");
            return;
        }
    }
    public void DetermineDirection(InputAction.CallbackContext context)
    {
        _sight.transform.position = context.ReadValue<Vector2>();
    }

    public void DashDirection(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _dashDirection = (_sight.transform.position - transform.position).normalized;
            _dash.DashTowards(_dashDirection);
        }
    }
}
