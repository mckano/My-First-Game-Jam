using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// This 2D physics script should be attached to the parent of a 3D mesh with movement animations

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D myRigidbody;
    Collider2D myCollider;
    Animator meshAnimator;

    bool isTakeOff = false;
    float takeOffDuration = 0.25f;

    public float movementSpeed;
    public float jumpForce;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        meshAnimator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        // Here we account for left/right movement
        float speedX = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        myRigidbody.velocity = new Vector2(speedX * movementSpeed, myRigidbody.velocity.y);

        // This boolean is accounted for in the switch between idle and running
        meshAnimator.SetBool("isMovementSpeed", Mathf.Abs(speedX) > 0);

        // Rotate the player in the direction it's facing
        if (speedX > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (speedX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void Update()
    {
        meshAnimator.SetBool("isGrounded", IsGrounded());
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !isTakeOff)
        {
            isTakeOff = true;
            meshAnimator.SetBool("isTakeOff", isTakeOff);
            Invoke("Jump", takeOffDuration);
        }
    }

    bool IsGrounded()
    {
        Vector3 legsCenterPosition = new Vector3(myCollider.bounds.center.x, myCollider.bounds.min.y, myCollider.bounds.center.z);
        RaycastHit2D hitObject = Physics2D.Raycast(legsCenterPosition + Vector3.down * 0.1f, Vector2.down, 0.1f);
        return hitObject; // we cast to a boolean, so false is returned if hitObject is null
    }

    void Jump()
    {
        myRigidbody.AddForce(new Vector2(0, jumpForce));
        isTakeOff = false;
        meshAnimator.SetBool("isTakeOff", isTakeOff);
    }
}