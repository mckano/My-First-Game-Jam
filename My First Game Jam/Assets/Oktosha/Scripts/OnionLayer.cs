using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionLayer : MonoBehaviour
{
    // -- Movement controls --

    // controls the amount of rotation that moves the object
    public float torque;

    // controls the amount shift in the desired direction to get unstuck
    // should be a small value, as the main control is done by torque
    public float directTransformShift;

    // -- End Movement controls --

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // -- Movement --

        float input = Input.GetAxis("Horizontal");

        // primary way of movement -> rotate itself to roll
        rb.AddTorque(-torque * input);

        // small shift in the desired direction to get unstuck
        transform.position += Vector3.right * input * directTransformShift;

        // -- End Movement --
    }
}
