using UnityEngine;

public class Win : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.WinSound);
        }
    }
}
