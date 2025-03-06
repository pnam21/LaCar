using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishPoint : MonoBehaviour
{
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
            SceneController.instance.NextLevel();
        }
    }
}
