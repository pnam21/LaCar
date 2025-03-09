using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------ Audio Source ------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("------ Audio Clip ------")]
    public AudioClip theme1;
    public AudioClip theme2;
    public AudioClip theme3;
    public AudioClip theme4;
    public AudioClip squash;
    public AudioClip gameover;
    public AudioClip gas;
    public AudioClip finish;
    private void Start()
    {
        musicSource.clip = theme1;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) { 
        SFXSource.PlayOneShot(clip);
    }

}
