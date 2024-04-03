using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    HingeJoint2D HJ;
    Collider2D coll;
    Rigidbody2D rb;
    [SerializeField] LayerMask layerMask;

    private void Awake()
    {
        HJ = GetComponent<HingeJoint2D>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void Scatter()
    {
        Destroy(HJ);
        coll.excludeLayers = layerMask;
        rb.gravityScale = 1;
        Destroy(gameObject, 5);
    }
}
