using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] string levelName;
    [SerializeField] private GameObject gameovercanvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1.0f;

    }

    public void GameOver()
    {
        gameovercanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        FuelController.instance.FillFuel();
        SceneController.instance.LoadScene(levelName);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
