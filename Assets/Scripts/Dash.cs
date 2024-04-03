using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool canDash = true;
    Rigidbody2D rb;
    float _dashForce = 50f;
    [SerializeField] Drop _drop;
    [SerializeField] Collisions _collisions;
    [SerializeField] PlayerInputs _playerInputs;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void DashTowards(Vector2 _dashDirection)
    {
        if (canDash)
        {
            if (_collisions.GluedDown && _playerInputs._sight.transform.localPosition.y < 0) return;
            if(_collisions.GluedUp && _playerInputs._sight.transform.localPosition.y > 0) return;
            if(_collisions.GluedLeft && _playerInputs._sight.transform.localPosition.x < 0) return;
            if (_collisions.GluedRight && _playerInputs._sight.transform.localPosition.x > 0) return;
            _drop.LetGo();
            //AudioManager.Instance.PlaySFX(AudioManager.Instance.dashSound, 1, 1);
            _collisions.Attack = true;
            rb.AddForce(_dashDirection.normalized * _dashForce, ForceMode2D.Impulse);
            canDash = false;
        }
    }
}


