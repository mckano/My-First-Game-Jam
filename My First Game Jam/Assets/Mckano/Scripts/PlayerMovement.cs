using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    Collider2D cldr;

    public float movementSpeed;
    public float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cldr = GetComponent<Collider2D>();
    }

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
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Vector3 legsCenterPosition = new Vector3(cldr.bounds.center.x, cldr.bounds.min.y, cldr.bounds.center.z);
            Debug.DrawLine(legsCenterPosition, legsCenterPosition + Vector3.down * 0.1f, Color.green);
            RaycastHit2D hitObject = Physics2D.Raycast(legsCenterPosition + Vector3.down * 0.1f, Vector2.down, 0.1f);
            if (hitObject)
            {
                Debug.Log("I can jump because I stand on " + hitObject.collider.gameObject.name);
                rb.AddForce(new Vector2(0, jumpForce));
            }
        }
    }
}