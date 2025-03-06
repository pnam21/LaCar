using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 10; // Số điểm khi thu thập xu

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Vehicle")) // Kiểm tra nếu xe chạm vào xu
        {
            GameManager.instance.AddScore(scoreValue); // Cộng điểm
            Destroy(gameObject); // Xóa đồng xu khỏi game
        }
    }
}