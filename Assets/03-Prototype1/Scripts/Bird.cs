using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Rigidbody rb;
    //Variables that let me adjust gravity and jump
    public float sphereGravity = -10.0f;
    public float jumpAmount = 10;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        Vector3 gravity = sphereGravity * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }
}
