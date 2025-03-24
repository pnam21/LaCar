using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public static int totalScore = 0;
    public int scoreValue = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Vehicle"))
        {
            audioManager.PlaySFX(audioManager.squash);
            totalScore += scoreValue;

            // Cập nhật điểm thông qua GameManager
            if (GameManager.instance != null)
            {
                GameManager.instance.UpdateScoreUI();
            }

            Destroy(gameObject);
        }
    }

    public static void ResetScore()
    {
        totalScore = 0;
        // Cập nhật UI thông qua GameManager
        if (GameManager.instance != null)
        {
            GameManager.instance.UpdateScoreUI();
        }
    }
}