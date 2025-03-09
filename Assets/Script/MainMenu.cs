using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel; // Panel cài ??t

    public void PlayGame()
    {
        SceneManager.LoadScene("scene1"); // Chuy?n sang màn ch?i
    }
    public void OpenSettings()
    {
        settingsPanel.SetActive(true); // Hi?n c?a s? cài ??t
    }
    public void SaveSettings()
    {
        settingsPanel.SetActive(false); // ?óng c?a s? cài ??t
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false); // ?óng c?a s? cài ??t
    }

    public void QuitGame()
    {
        Application.Quit(); // Thoát game
    }
}