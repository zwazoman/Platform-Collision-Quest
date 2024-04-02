using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    [SerializeField] Dash _dash;
    Rigidbody2D _rb;
    public bool IsGlued { get; set; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            _dash.canDash = true;
            _rb.velocity = Vector2.zero;
            _rb.constraints = RigidbodyConstraints2D.FreezePosition;
            IsGlued = true;
            //AudioManager.Instance.PlaySFX(AudioManager.Instance.impactSound, 1, Random.Range(0.8f, 1.2f));
            print("collé au mur");
        }
    }
}
