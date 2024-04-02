using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool canDash = true;
    Rigidbody2D rb;
    [SerializeField] float dashForce;
    [SerializeField] Drop _drop;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void DashTowards(Vector2 _dashDirection)
    {
        if (canDash)
        {
            _drop.LetGo();
            //AudioManager.Instance.PlaySFX(AudioManager.Instance.dashSound, 1, 1);
            rb.velocity = _dashDirection.normalized * dashForce;
            canDash = false;
            print("dash");
        }
        else
        {
            print("can't dash");
        }
    }
}


