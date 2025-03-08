using UnityEngine;

public class CollectFuel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Vehicle"))
        {
            FuelController.instance.FillFuel();
            Destroy(gameObject);
        }
    }
}
