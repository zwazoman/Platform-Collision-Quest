using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glued : MonoBehaviour
{
    [field:HideInInspector]
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

    private void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, _rayLength, _layerMask.value) && _playerInputs._sight.transform.position.y < transform.position.y)
        {
            GluedDown = true;
        }
        if (Physics2D.Raycast(transform.position, Vector2.up, _rayLength, _layerMask.value) && _playerInputs._sight.transform.position.y > transform.position.y)
        {
            GluedUp = true;
        }
        if (Physics2D.Raycast(transform.position, Vector2.left, _rayLength, _layerMask.value) && _playerInputs._sight.transform.position.x < transform.position.x)
        {
            GluedLeft = true;
        }
        if (Physics2D.Raycast(transform.position, Vector2.right, _rayLength, _layerMask.value) && _playerInputs._sight.transform.position.x > transform.position.x)
        {
            GluedRight = true;
        }
    }
}
