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
    public TextMeshProUGUI scoreText; 

    private void Start()
    {
       
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        UpdateScoreUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Vehicle")) 
        {
            audioManager.PlaySFX(audioManager.squash);
            totalScore += scoreValue;
            UpdateScoreUI(); 
            Destroy(gameObject); 
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + totalScore;
        }
    }
}