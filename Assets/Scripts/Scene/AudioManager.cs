using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance = null;
    public static AudioManager Instance => _instance;

    [Header("AudioSources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Musics")]
    public AudioClip music;
    [Header("SFX")]
    public List<AudioClip> DashSounds = new List<AudioClip>();   
    public List<AudioClip> BodySounds = new List<AudioClip>();
    public List<AudioClip> EnemySounds = new List<AudioClip>();
    public AudioClip ImpactSound;
    public AudioClip SolidImpactSound;
    public AudioClip DropSound;
    public AudioClip BumperSound;
    public AudioClip DeathSound;
    public AudioClip WinSound;
    public AudioClip SlowSound;


    private void Awake()
    {
        // Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
            this.transform.SetParent(null);
        }
    }
    public void PlaySFX(AudioClip clip, float _volume = 1, float _pitch = 1)
    {
        SFXSource.volume = _volume;
        SFXSource.pitch = _pitch;
        SFXSource.PlayOneShot(clip);
    }

    // "Music by Karl Casey @ White Bat Audio"
}
