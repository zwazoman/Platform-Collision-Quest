using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    [SerializeField] CinemachineVirtualCamera _vCam;
    [SerializeField] GameObject _spawnPoint;
    [SerializeField] GameObject _playerPrefab;
    [field:HideInInspector]
    public GameObject Player { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Player = Instantiate(_playerPrefab, _spawnPoint.transform.position, Quaternion.identity);
        _vCam.Follow = Player.transform;
    }
}
