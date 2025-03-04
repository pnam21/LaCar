using UnityEngine;

public class WheelDustEffect : MonoBehaviour
{
    public ParticleSystem dustEffect; // Gán Particle System trong Inspector

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Ki?m tra va ch?m v?i m?t ??t
        {
            dustEffect.Play(); // Ch?y hi?u ?ng b?i
        }
    }
}