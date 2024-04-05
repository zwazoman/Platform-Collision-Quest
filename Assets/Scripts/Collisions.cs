using UnityEngine;

public class Collisions : MonoBehaviour
{
    [SerializeField] Dash _dash;
    [SerializeField] Death _death;
    [SerializeField] GameObject _softWallParticles;
    Rigidbody2D _rb;
    Collider2D _coll;
    [field:HideInInspector]
    public bool Attack { get; set; }

    [field: HideInInspector]
    public bool GluedDown { get; set; }

    [field: HideInInspector]
    public bool GluedUp { get; set; }

    [field: HideInInspector]
    public bool GluedLeft { get; set; }

    [field: HideInInspector]
    public bool GluedRight { get; set; }

    float _rayLength = 0.4f;
    [SerializeField] LayerMask _layerMask;
    public bool IsGlued { get; set; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _coll = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            Attack = false;
            _dash.canDash = true;
            _rb.velocity = Vector2.zero;
            _rb.constraints = RigidbodyConstraints2D.FreezePosition;
            IsGlued = true;
            /*RaycastHit2D[] hit2dDown = new RaycastHit2D[1];
            if (_coll.Cast(Vector2.down, hit2dDown, 0.1f) > 0) { GluedDown = true; print("down"); }
            RaycastHit2D[] hit2dUp = new RaycastHit2D[1];
            if (_coll.Cast(Vector2.up, hit2dUp, 0.1f) > 0) { GluedUp = true; print("up"); }
            RaycastHit2D[] hit2dLeft = new RaycastHit2D[1];
            if (_coll.Cast(Vector2.left, hit2dLeft, 0.1f) > 0) { GluedLeft = true; print("left"); }
            RaycastHit2D[] hit2dRight = new RaycastHit2D[1];
            if (_coll.Cast(Vector2.right, hit2dRight, 0.1f) > 0) {GluedRight = true; print("right"); }*/
            if (Physics2D.Raycast(transform.position, Vector2.down, _rayLength, _layerMask.value)) { GluedDown = true; print("GluedDown"); }

            if (Physics2D.Raycast(transform.position, Vector2.up, _rayLength, _layerMask.value)) { GluedUp = true; print("GluedUp"); }

            if (Physics2D.Raycast(transform.position, Vector2.left, _rayLength, _layerMask.value)) { GluedLeft = true; print("GluedLeft"); }

            if (Physics2D.Raycast(transform.position, Vector2.right, _rayLength, _layerMask.value)) { GluedRight = true; print("GluedRight"); }

            AudioManager.Instance.PlaySFX(AudioManager.Instance.ImpactSound, 1f, Random.Range(0.8f, 1.2f));
            GameObject particle = Instantiate(_softWallParticles, transform.position, Quaternion.identity);
            Destroy(particle, 1);
        }
        if(collision.gameObject.layer == 6)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.SolidImpactSound,2f);
        }
        if ( collision.gameObject.layer == 8)
        {
            _death.Kill();
        }
        if (collision.gameObject.layer == 9)
        {
            if (Attack)
            {
                gameObject.SendMessage("Kill");
            }
            else
            {
                _death.Kill();
            }
        }
        if(collision.gameObject.layer == 10)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.BumperSound);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        GluedDown = false;
        GluedUp = false;
        GluedLeft = false;        
        GluedRight = false;
        IsGlued = false;
    }
}
