using UnityEngine;
using UnityEngine.VFX;

public class Dash : MonoBehaviour
{
    public bool canDash = true;
    Rigidbody2D rb;
    float _dashForce = 30f;
    [SerializeField] Drop _drop;
    [SerializeField] Collisions _collisions;
    [SerializeField] PlayerInputs _playerInputs;
    [SerializeField] public GameObject _cameraTarget;
    [SerializeField] VisualEffect _smokeEffect;

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
            _collisions.GluedDown = false;
            _collisions.GluedUp = false;
            _collisions.GluedLeft = false;
            _collisions.GluedRight = false;
            _collisions.IsGlued = false;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            print(rb.constraints);
            AudioManager.Instance.PlaySFX(AudioManager.Instance.DashSounds[Random.Range(0, AudioManager.Instance.DashSounds.Count)]);
            _collisions.Attack = true;
            _smokeEffect.Play();
            rb.AddForce(_dashDirection.normalized * _dashForce, ForceMode2D.Impulse);
            canDash = false;
        }
    }
}


