using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;

    public float movementSpeed;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float speedX = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

        rb.velocity = new Vector2(speedX * movementSpeed, rb.velocity.y);
    }

    private void Update()
    {
        Jump();
    }

    void Jump()
    {
        Vector3 offsetY = new Vector3(0, (transform.localScale.y / 2) + 0.1f, 0);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (Physics2D.Raycast(transform.position - offsetY, Vector2.down, 0.1f))
            {
                rb.AddForce(new Vector2(0, jumpForce));
            }
        }
    }
}