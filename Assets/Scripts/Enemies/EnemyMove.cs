using UnityEngine;

public class EnemyMove : MonoBehaviour
{
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
}
