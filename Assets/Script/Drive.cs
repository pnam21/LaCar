using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Drive : MonoBehaviour
{
    [SerializeField] private Rigidbody2D frontTireRB;
    [SerializeField] private Rigidbody2D backTireRB;
    [SerializeField] private Rigidbody2D carRB;
    [SerializeField] private float speed = 75f;
    [SerializeField] private float rotationSpeed = 300f;

    private float moveInput;

    private void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

    }

    private void FixedUpdate()
    {
        frontTireRB.AddTorque(-moveInput * speed * Time.deltaTime);
        backTireRB.AddTorque(-moveInput * speed * Time.deltaTime);
        carRB.AddTorque(moveInput * rotationSpeed * Time.fixedDeltaTime);
    }

}
