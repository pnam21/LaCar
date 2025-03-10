using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class FuelController : MonoBehaviour
{
    AudioManager audioManager;
    
    public static FuelController instance;
    [SerializeField] private Image fuelImage;
    [SerializeField, Range(0.1f,5f)] private float fuelDrainSpeed = 1f;
    [SerializeField] private float maxFuelAmmount = 100f;
    [SerializeField] private Gradient fuelGradient;
    private float currentFuelAmmount;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        currentFuelAmmount = maxFuelAmmount;
        UpdateUI();
    }
    public void Update()
    {
        currentFuelAmmount -= Time.deltaTime * fuelDrainSpeed;
        UpdateUI();
        if (currentFuelAmmount <= 0f) {
            audioManager.PlaySFX(audioManager.gameover);
            GameManager.instance.GameOver();
        }
    }
    private void UpdateUI()
    {
        fuelImage.fillAmount = (currentFuelAmmount / maxFuelAmmount);
        fuelImage.color = fuelGradient.Evaluate(fuelImage.fillAmount);
    }
    public void FillFuel()
    {
        currentFuelAmmount = maxFuelAmmount;
        UpdateUI();
    }
}
