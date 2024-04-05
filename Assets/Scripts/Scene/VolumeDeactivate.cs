using UnityEngine;
using UnityEngine.Rendering;

public class VolumeDeactivate : MonoBehaviour
{
    [SerializeField] Volume _volume;
    [SerializeField] Spawner _spawner;
    bool _active = false;


    private void Start()
    {
        _spawner.OnSpawn += DeactivateVolume;
    }

    private void Update()
    {
        if (!_active) return;
        _volume.weight = Mathf.Lerp(_volume.weight, 0f, .02f);
        if(_volume.weight < 0.01f)
        {
            _volume.weight = 0;
            _active = false;
        }
    }

    private void DeactivateVolume()
    {
        _active = true;
    }
}
