using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool canDash = true;
    float rayLength = 0.19f;
    public LayerMask layerMask;
    Rigidbody2D rb;
    public Vector3 dashDirection;
    [SerializeField] float dashForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void DashTowards(Vector2 _dashDirection)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canDash)
            {
                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPosition.z = 0;
                dashDirection = mouseWorldPosition - transform.position;
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
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                //AudioManager.Instance.PlaySFX(AudioManager.Instance.dashSound, 1, 1);
                rb.velocity = dashDirection.normalized * dashForce;
                canDash = false;
                print("dash");

            }
            else
            {
                print("can't dash");
            }

        }

    }
}


