using UnityEngine;

public class Explode : MonoBehaviour
{
    HingeJoint2D HJ;
    Collider2D coll;
    Rigidbody2D rb;
    [SerializeField] LayerMask layerMask;
    bool _isScattered;

    private void Awake()
    {
        HJ = GetComponent<HingeJoint2D>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isScattered) return;
        AudioManager.Instance.PlaySFX(AudioManager.Instance.BodySounds[Random.Range(0, AudioManager.Instance.BodySounds.Count)]);
    }

    public void Scatter()
    {
        _isScattered = true;
        Destroy(HJ);
        coll.excludeLayers = layerMask;
        rb.gravityScale = 1;
        Destroy(gameObject, 5);
    }
}
