using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject gameovercanvas;
    [SerializeField] private GameObject PauseMenu;

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
        if (gameovercanvas != null)
        {
            gameovercanvas.tag = "Untagged";
            gameovercanvas.SetActive(false);
        }
        if (PauseMenu != null)
        {
            PauseMenu.tag = "Untagged";
            PauseMenu.SetActive(false);
        }
    }

    public void GameOver()
    {
        if (gameovercanvas != null)
        {
            gameovercanvas.SetActive(true);
            DontDestroyOnLoad(gameovercanvas);
        }
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        FuelController.instance.FillFuel();
        Debug.Log("index = " + SceneManager.GetActiveScene().buildIndex);

        if (gameovercanvas != null)
        {
            gameovercanvas.SetActive(false);
        }
        if (PauseMenu != null)
        {
            PauseMenu.SetActive(false);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}