using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel;  // Panel cài đặt
    public Slider volumeSlider;       // Thanh trượt âm lượng
    private float savedVolume;        // Lưu giá trị âm lượng trước đó

    private void Start()
    {
        // Ẩn menu cài đặt khi bắt đầu game
        settingsPanel.SetActive(false);

        // Lấy giá trị âm lượng đã lưu (hoặc mặc định)
        savedVolume = PlayerPrefs.GetFloat("SavedVolume", AudioListener.volume);
        volumeSlider.value = savedVolume;
    }

    // Mở menu cài đặt
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        volumeSlider.value = savedVolume; // Đưa về giá trị đã lưu trước đó
    }

    // Đóng menu cài đặt mà không lưu thay đổi
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        volumeSlider.value = savedVolume; // Hoàn tác về giá trị cũ
    }

    // Cập nhật âm lượng tạm thời
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    // Lưu cài đặt âm lượng
    public void SaveSettings()
    {
        savedVolume = volumeSlider.value; // Cập nhật giá trị đã lưu
        PlayerPrefs.SetFloat("SavedVolume", savedVolume);
        PlayerPrefs.Save();
        settingsPanel.SetActive(false); // Đóng menu sau khi lưu
    }

    // Hủy thay đổi, trở về giá trị cũ
    public void CancelSettings()
    {
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume);
        settingsPanel.SetActive(false);
    }
}