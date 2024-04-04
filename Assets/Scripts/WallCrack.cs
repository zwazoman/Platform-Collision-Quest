using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCrack : MonoBehaviour
{
    SpriteRenderer _sr;
    [SerializeField] Sprite _crackedSprite;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            _sr.sprite = _crackedSprite;
        }
    }
}
