using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject PauseMenu;

    [Header("Game Over UI")]
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private Button playAgainButton;

    [Header("Game Win UI")]
    [SerializeField] private TextMeshProUGUI gameWinText;
    [SerializeField] private TextMeshProUGUI winScoreText;
    [SerializeField] private Button HomeButton;

    [Header("Game UI")]
    [SerializeField] private Canvas gameCanvas; // Canvas chứa UI trong game
    [SerializeField] private TextMeshProUGUI scoreText; // Reference trực tiếp đến ScoreText



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1.0f;

        // Ẩn UI Game Over khi bắt đầu
        HideGameOverUI();
        HideGameWinUI();
    }

    private void Start()
    {
        // Thêm sự kiện cho các nút
        if (playAgainButton != null)
            playAgainButton.onClick.AddListener(RestartGame);
        if (HomeButton != null)
            HomeButton.onClick.AddListener(GoHome);

        // Đảm bảo UI Score được hiển thị
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(true);
            UpdateScoreUI();
        }
    }

    public void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Enemy.totalScore.ToString();
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(InitializeUIAfterLoad());
    }

    private IEnumerator InitializeUIAfterLoad()
    {
        // Đợi một frame để đảm bảo tất cả objects đã được tạo
        yield return null;

        if (PauseMenu != null)
        {
            PauseMenu.tag = "Untagged";
            PauseMenu.SetActive(false);
        }

        // Hiển thị UI Score
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(true);
            UpdateScoreUI();
        }

        GameObject fuelBar = GameObject.Find("FuelBar");
        if (fuelBar != null)
        {
            fuelBar.SetActive(true);
        }
    }

    public void GameOver()
    {
        // Ẩn UI không cần thiết
        if (PauseMenu != null)
            PauseMenu.SetActive(false);

        if (scoreText != null)
            scoreText.gameObject.SetActive(false);

        GameObject fuelBar = GameObject.Find("FuelBar");
        if (fuelBar != null)
            fuelBar.SetActive(false);

        // Hiển thị UI Game Over
        ShowGameOverUI();
        Time.timeScale = 0f;
    }

    private void ShowGameOverUI()
    {
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(true);

        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + Enemy.totalScore.ToString();
            finalScoreText.gameObject.SetActive(true);
        }

        if (playAgainButton != null)
            playAgainButton.gameObject.SetActive(true);
    }
    public void GameWin()
    {
        // Ẩn UI không cần thiết
        if (PauseMenu != null)
            PauseMenu.SetActive(false);

        if (scoreText != null)
            scoreText.gameObject.SetActive(false);

        GameObject fuelBar = GameObject.Find("FuelBar");
        if (fuelBar != null)
            fuelBar.SetActive(false);

        // Hiển thị UI Game Over
        WinGameUI();
        Time.timeScale = 0f;
    }

    private void WinGameUI()
    {
        if (gameWinText != null)
            gameWinText.gameObject.SetActive(true);

        if (winScoreText != null)
        {
            winScoreText.text = "Final Score: " + Enemy.totalScore.ToString();
            winScoreText.gameObject.SetActive(true);
        }

        if (HomeButton != null)
            HomeButton.gameObject.SetActive(true);
    }

    private void HideGameOverUI()
    {
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);

        if (finalScoreText != null)
            finalScoreText.gameObject.SetActive(false);

        if (playAgainButton != null)
            playAgainButton.gameObject.SetActive(false);
    }

    private void HideGameWinUI()
    {
        if (gameWinText != null)
            gameWinText.gameObject.SetActive(false);

        if (winScoreText != null)
            winScoreText.gameObject.SetActive(false);

        if (HomeButton != null)
            HomeButton.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        Enemy.totalScore = 0; // Reset điểm về 0
        FuelController.instance.FillFuel();
        Time.timeScale = 1.0f;
        HideGameOverUI();
        HideGameWinUI();

        if (PauseMenu != null)
        {
            PauseMenu.SetActive(false);
        }

        // Hiển thị lại UI Score trước khi load scene
        if (scoreText != null)
        {
            scoreText.gameObject.SetActive(true);
            UpdateScoreUI();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoHome()
    {
        Enemy.totalScore = 0; // Reset điểm về 0
        FuelController.instance.FillFuel();
        Time.timeScale = 1.0f;
        HideGameOverUI();
        HideGameWinUI();
        Destroy(GameObject.Find("GameManager"));

        if (PauseMenu != null)
        {
            PauseMenu.SetActive(false);
        }

        

        SceneManager.LoadScene("MainMenu");
    }
}
