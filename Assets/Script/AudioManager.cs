//using UnityEngine;

//public class AudioManager : MonoBehaviour
//{
//    [Header("------ Audio Source ------")]
//    [SerializeField] AudioSource musicSource;
//    [SerializeField] AudioSource SFXSource;
//    [Header("------ Audio Clip ------")]
//    public AudioClip theme1;
//    public AudioClip theme2;
//    public AudioClip theme3;
//    public AudioClip theme4;
//    public AudioClip squash;
//    public AudioClip gameover;
//    public AudioClip gas;
//    public AudioClip finish;
//    private void Start()
//    {
//        musicSource.clip = theme1;
//        musicSource.Play();
//    }

//    public void PlaySFX(AudioClip clip) { 
//        SFXSource.PlayOneShot(clip);
//    }

//}


using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("------ Audio Source ------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("------ Audio Clip ------")]
    public AudioClip theme;
    public AudioClip squash;
    public AudioClip gameover;
    public AudioClip gas;
    public AudioClip finish;

    [Header("------ UI Elements ------")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private const string MusicVolumeKey = "MusicVolume";
    private const string SFXVolumeKey = "SFXVolume";

    private void Start()
    {
        // Load volume settings
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
        float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 1f);

        musicSource.volume = savedMusicVolume;
        SFXSource.volume = savedSFXVolume;

        // Set slider values
        if (musicSlider != null)
        {
            musicSlider.value = savedMusicVolume;
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }

        if (sfxSlider != null)
        {
            sfxSlider.value = savedSFXVolume;
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        }

        // Start playing the first theme
        musicSource.clip = theme;
        musicSource.Play();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume)
    {
        SFXSource.volume = volume;
        PlayerPrefs.SetFloat(SFXVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
