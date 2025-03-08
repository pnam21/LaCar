using UnityEngine;
using TMPro; // Th�m th? vi?n TextMeshPro

public class Enemy : MonoBehaviour
{
    public static int totalScore = 0; // Bi?n t?nh l?u t?ng ?i?m
    public int scoreValue = 10; // ?i?m c?ng khi ti�u di?t enemy
    public TextMeshProUGUI scoreText; // UI hi?n th? ?i?m

    private void Start()
    {
        // T�m ??i t??ng ScoreText trong scene
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        UpdateScoreUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Vehicle")) // N?u xe ch?m v�o enemy
        {
            totalScore += scoreValue; // C?ng ?i?m
            UpdateScoreUI(); // C?p nh?t UI
            Destroy(gameObject); // X�a enemy
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