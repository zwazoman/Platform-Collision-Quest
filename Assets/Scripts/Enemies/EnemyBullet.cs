using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private void FixedUpdate()
    {
        transform.Translate(_player.transform.position - transform.position);
    }
}
