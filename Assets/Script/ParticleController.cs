using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;
    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;
    [Range(0, 0.2f)]
    [SerializeField] float dustFormationPeriod;
    [SerializeField] Rigidbody2D carRb;
    [SerializeField] ParticleSystem fallParticle;
    float counter;
    bool isOnGround;
    private void Update()
    {
        counter += Time.deltaTime;
        if (isOnGround && Mathf.Abs(carRb.linearVelocity.x) > occurAfterVelocity)
        {
            if (counter > dustFormationPeriod) {
                movementParticle.Play();
                counter = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
           if (collision.CompareTag("Ground"))
        {
            fallParticle.Play();
            isOnGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }

}
