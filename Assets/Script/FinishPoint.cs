using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] bool goNextLevel;
    [SerializeField] string levelName;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] float delayBeforeLoad = 1f;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio")?.GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vehicle"))
        {
            if (finishEffect != null)
            {
                finishEffect.transform.position = transform.position;
                finishEffect.Play();
            }

            FuelController.instance?.FillFuel();
            audioManager?.PlaySFX(audioManager.finish);

            StartCoroutine(DelayBeforeNextScene());
        }
    }

    private IEnumerator DelayBeforeNextScene()
    {
        yield return new WaitForSeconds(delayBeforeLoad);

        if (goNextLevel)
        {
            SceneController.instance.NextLevel();
        }
        else
        {
            SceneController.instance.LoadScene(levelName);
        }
    }
}
