using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetMove : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private void Update()
    {
        transform.position = (Vector2)_player.transform.position + _player.GetComponent<Rigidbody2D>().velocity / 3;
    }

    private void OnDestroy()
    {
        //transform.position = _player.transform.position;
    }
}
