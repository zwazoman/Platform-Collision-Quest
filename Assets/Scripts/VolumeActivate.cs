using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class VolumeActivate : MonoBehaviour
{
    [SerializeField] Volume _volume;
    [SerializeField] Spawner _spawner;
    public bool Active = false;

    private void Start()
    {
        _spawner.OnSpawn += DeactivateVolume;
    }

    private void Update()
    {
        if (!Active) return;
        _volume.weight = Mathf.Lerp(_volume.weight,1f,.01f);
    }

    private void DeactivateVolume()
    {
        Active = false;
    }
}
