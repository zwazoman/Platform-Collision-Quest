using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Drop : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float _dropForce = 1f;
    [SerializeField] Collisions _collisions;
    [SerializeField] Glued _glued;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnDrop(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            LetGo();
        }
    }

    public void LetGo()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (_glued.GluedLeft) rb.AddForce(Vector2.right * _dropForce);
        if (_glued.GluedRight) rb.AddForce(Vector2.left * _dropForce);

        _collisions.IsGlued = false;
    }
}
