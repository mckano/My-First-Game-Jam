using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionLayer : MonoBehaviour
{
    public float torque;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float turn = Input.GetAxis("Horizontal");
        rb.AddTorque(-torque * turn);
    }
}
