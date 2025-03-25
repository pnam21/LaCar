using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel; 

    public void PlayGame()
    {
        SceneManager.LoadScene("scene1"); 
    }
    public void OpenSettings()
    {
        settingsPanel.SetActive(true); 
    }
    public void SaveSettings()
    {
        settingsPanel.SetActive(false); 
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}