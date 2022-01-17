using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionLayer : MonoBehaviour
{
    public float torque;
    public float directTransformShift;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float input = Input.GetAxis("Horizontal");
        rb.AddTorque(-torque * input);
        transform.position += Vector3.right * input * directTransformShift;
    }
}
