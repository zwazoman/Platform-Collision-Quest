using UnityEngine;
using UnityEngine.Rendering;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] Volume _volume;
    float _targetedWeight = 1f;
    float _initialWeight = 0f;
    public bool Ismaxed = true;

    private void Update()
    {
        if (Ismaxed)
        {
            _volume.weight = Mathf.Lerp(_volume.weight, _targetedWeight, .02f);
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0.5f, .09f);
        }
        else
        {
            _volume.weight = Mathf.Lerp(_volume.weight, _initialWeight, .05f);
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, .09f);

        }
        if (_volume.weight >= _targetedWeight - 0.1f)
        {
            print("maxed");
            Ismaxed = false;
        }
        if (_volume.weight <= _initialWeight + 0.1f && !Ismaxed)
        {
            gameObject.SetActive(false);
        }
    }
}
