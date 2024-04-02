using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Collisions : MonoBehaviour
{
    [SerializeField] Dash _dash;
    Rigidbody2D _rb;
    [field: HideInInspector]
    public bool GluedDown { get; set; }

    [field: HideInInspector]
    public bool GluedUp { get; set; }

    [field: HideInInspector]
    public bool GluedLeft { get; set; }

    [field: HideInInspector]
    public bool GluedRight { get; set; }

    [SerializeField] PlayerInputs _playerInputs;
    float _rayLength = 0.5f;
    [SerializeField] LayerMask _layerMask;
    public bool IsGlued { get; set; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            print("suuu");
            _dash.canDash = true;
            _rb.velocity = Vector2.zero;
            _rb.constraints = RigidbodyConstraints2D.FreezePosition;
            IsGlued = true;
            if (Physics2D.Raycast(transform.position, Vector2.down, _rayLength, _layerMask.value))
            {
                GluedDown = true;
                print("GlueDown");
            }
            if (Physics2D.Raycast(transform.position, Vector2.up, _rayLength, _layerMask.value))
            {
                GluedUp = true;
                print("GluedUp");
            }
            if (Physics2D.Raycast(transform.position, Vector2.left, _rayLength, _layerMask.value))
            {
                GluedLeft = true;
                print("GluedLeft");
            }
            if (Physics2D.Raycast(transform.position, Vector2.right, _rayLength, _layerMask.value))
            {
                GluedRight = true;
                print("GluedRight");
            }
            //AudioManager.Instance.PlaySFX(AudioManager.Instance.impactSound, 1, Random.Range(0.8f, 1.2f));
            print("collé au mur");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        GluedDown = false;
        GluedUp = false;
        GluedLeft = false;
        GluedRight = false;

    }
}
