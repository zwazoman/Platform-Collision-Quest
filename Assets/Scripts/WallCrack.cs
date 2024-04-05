using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCrack : MonoBehaviour
{
    SpriteRenderer _sr;
    [SerializeField] Sprite _crackedSprite;
    [SerializeField] Sprite _hitSprite;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            StartCoroutine(ChangeWall());
        }
    }

    IEnumerator ChangeWall()
    {
        _sr.sprite = _hitSprite;
        yield return new WaitForSeconds(.2f);
        _sr.sprite = _crackedSprite;
    }
}
