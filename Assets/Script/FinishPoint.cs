using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    public string Level; // Tên level cần load
    public ParticleSystem fireworksEffect; // Gán hiệu ứng pháo hoa trong Inspector

    private void Start()
    {
        fireworksEffect.Stop(); // Tắt hiệu ứng khi bắt đầu
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vehicle")) // Kiểm tra nếu xe chạm vạch đích
        {
            fireworksEffect.Play(); // Bật hiệu ứng pháo hoa
            Debug.Log("🚗 Xe đã về đích! 🎆");

            StartCoroutine(LoadNextLevel()); // Chuyển cảnh sau vài giây
        }
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(5f); // Chờ 2 giây để hiệu ứng chạy
        SceneManager.LoadScene(Level); // Chuyển sang level mới
    }
}