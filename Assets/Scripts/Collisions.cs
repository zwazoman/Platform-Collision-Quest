using UnityEngine;

public class Collisions : MonoBehaviour
{
    [SerializeField] Dash _dash;
    [SerializeField] Death _death;
    Rigidbody2D _rb;
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
            Attack = false;
            _dash.canDash = true;
            _rb.velocity = Vector2.zero;
            _rb.constraints = RigidbodyConstraints2D.FreezePosition;
            IsGlued = true;
            if (Physics2D.Raycast(transform.position, Vector2.down, _rayLength, _layerMask.value)) GluedDown = true;

            if (Physics2D.Raycast(transform.position, Vector2.up, _rayLength, _layerMask.value)) GluedUp = true;

            if (Physics2D.Raycast(transform.position, Vector2.left, _rayLength, _layerMask.value)) GluedLeft = true;

            if (Physics2D.Raycast(transform.position, Vector2.right, _rayLength, _layerMask.value)) GluedRight = true;

            //AudioManager.Instance.PlaySFX(AudioManager.Instance.impactSound, 1, Random.Range(0.8f, 1.2f));
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
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        GluedDown = false;
        GluedUp = false;
        GluedLeft = false;
        GluedRight = false;

    }
}
