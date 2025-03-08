using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    //    public TextMeshProUGUI coinText; // Hiển thị "Coin:"
    public int scoreValue = 10; // Điểm nhận được khi nhặt xu
    public float delayTime = 2f;

    //   void Start()
    //   {
    //       if (coinText != null)
    //       {
    //           coinText.gameObject.SetActive(true); // Hiển thị "Coin:" ngay khi game bắt đầu
    //       }
    //   }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Vehicle")) // Nếu xe chạm vào xu
        {
            GameManager.instance.AddCoin(scoreValue); // Cộng điểm vào hệ thống
            Destroy(gameObject); // Xóa đồng xu khỏi game
        }
    }

}