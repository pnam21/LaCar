using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishPoint : MonoBehaviour
{
    [SerializeField] bool goNextLevel;
    [SerializeField] string levelName;
    //public string Level;
    //public void LoadLevel()
    //{
    //    SceneManager.LoadScene(Level);

    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Vehicle"))
    //    {
    //        LoadLevel();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vehicle"))
        {
            if (goNextLevel)
            {
                SceneController.instance.NextLevel();
            }
            else { 
                SceneController.instance.LoadScene(levelName);
            }

        }
    }
}
