using UnityEngine;
using UnityEngine.InputSystem;

public class Drop : MonoBehaviour
{
    Rigidbody2D rb;
    public bool CanDrop = true;
    [SerializeField] float _dropForce = 1f;
    [SerializeField] Collisions _collisions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void OnDrop(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!_collisions.IsGlued) return;
            AudioManager.Instance.PlaySFX(AudioManager.Instance.DropSound);
            LetGo();
        }
    }

    public void LetGo()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (_collisions.GluedLeft) rb.AddForce(Vector2.right * _dropForce);
        if (_collisions.GluedRight) rb.AddForce(Vector2.left * _dropForce);
    }
}
