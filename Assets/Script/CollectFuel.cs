using UnityEngine;

public class CollectFuel : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Vehicle"))
        {
            audioManager.PlaySFX(audioManager.gas);
            FuelController.instance.FillFuel();
            Destroy(gameObject);
        }
    }
}
