using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody rb;

    public float movementSpeed;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

        rb.velocity = new Vector3(horizontal * movementSpeed, rb.velocity.y, rb.velocity.z);
    }

    private void Update()
    {
        Jump();
    }
    void Jump()
    {
        float maxRayDistance = (transform.localScale.y / 2) + 0.1f;
        Vector3 offset = new Vector3(transform.localScale.x / 2, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position + offset, Vector3.down, maxRayDistance))
                rb.AddForce(0, jumpForce, 0);
            else if (Physics.Raycast(transform.position - offset, Vector3.down, maxRayDistance))
                rb.AddForce(0, jumpForce, 0);
        }
    }
}
