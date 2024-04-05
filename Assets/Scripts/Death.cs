using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using Random = UnityEngine.Random;

public class Death : MonoBehaviour
{
    [SerializeField] List<Explode> explodeList = new List<Explode>();
    [SerializeField] List<GameObject> bloodstains = new List<GameObject>();
    [SerializeField] GameObject _bloodParticles;
    public VolumeActivate _VolumeActivate { get; set; }
    CinemachineImpulseSource _impulseSource;

    private void Awake()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();    
    }

    public void Kill()
    {
        foreach(Explode explode in explodeList)
        {
            explode.transform.parent = null;
            explode.Scatter();
        }
        _impulseSource.GenerateImpulseWithForce(10);
        GameObject bloodStain = Instantiate(bloodstains[Random.Range(0, bloodstains.Count)], transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        Destroy(bloodStain, 30);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.DeathSound,2f);
        Instantiate(_bloodParticles, transform.position, Quaternion.identity);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.SlowSound);
        _VolumeActivate.Active = true;
        Spawner.instance.StartSpawn(1f);
        Destroy(gameObject);
    }
}
