using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] GameObject _bloodParticles;
    [SerializeField] float _speed;
    bool _goLeft;

    void FixedUpdate()
    {   
        if (_goLeft)
        {
            transform.Translate(Vector2.right * _speed* Time.deltaTime);
        }
        else if (!_goLeft)
        {
            transform.Translate(Vector2.right * -_speed* Time.deltaTime);
        }       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
             _goLeft=!_goLeft;
        }
    }

    public void Kill()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.EnemySounds[Random.Range(0,AudioManager.Instance.EnemySounds.Count)]);
        Instantiate(_bloodParticles, transform.position, Quaternion.identity); ;
        Destroy(gameObject);
    }
}
