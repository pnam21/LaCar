using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI; // Add this line
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMP_Text coinText; // Kéo UI Text vào đây
    private int coin = 0;
    [SerializeField] private int price = 10;
    [SerializeField] private GameObject gameovercanvas;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        //    DontDestroyOnLoad(gameObject);
        }
        //else
        //{
        //    Destroy(gameObject);
        //}
        Time.timeScale = 1.0f;

    }
    public void AddCoin(int amount)
    {
        coin += amount;
        coinText.text = "Coin: " + coin;
    }
    public void GameOver()
    {
        gameovercanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}