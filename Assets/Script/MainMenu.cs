using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel; // Panel c�i ??t

    public void PlayGame()
    {
        SceneManager.LoadScene("scene1"); // Chuy?n sang m�n ch?i
    }
    public void OpenSettings()
    {
        settingsPanel.SetActive(true); // Hi?n c?a s? c�i ??t
    }
    public void SaveSettings()
    {
        settingsPanel.SetActive(false); // ?�ng c?a s? c�i ??t
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false); // ?�ng c?a s? c�i ??t
    }

    public void QuitGame()
    {
        Application.Quit(); // Tho�t game
    }
}