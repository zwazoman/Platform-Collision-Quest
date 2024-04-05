using Cinemachine;
using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    [SerializeField] VolumeActivate _volumeActivate;
    [SerializeField] CinemachineVirtualCamera _vCam;
    [SerializeField] GameObject _spawnPoint;
    [SerializeField] GameObject _playerPrefab;
    [field:HideInInspector]
    public GameObject Player { get; private set; }
    public event Action OnSpawn;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartSpawn(0f);
    }

    public void StartSpawn(float _seconds)
    {
        StartCoroutine(Spawn(_seconds));
    }
    public IEnumerator Spawn(float _seconds)
    {
        yield return new WaitForSeconds(_seconds);
        Player = Instantiate(_playerPrefab, _spawnPoint.transform.position, Quaternion.identity);
        Player.GetComponent<Death>()._VolumeActivate = _volumeActivate;
        OnSpawn?.Invoke();
        _vCam.Follow = Player.GetComponent<Dash>()._cameraTarget.transform;
    }
}
