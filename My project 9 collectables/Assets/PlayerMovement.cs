using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
 public float moveSpeed = 5f;
 public float jumpForce = 5f;
 private Rigidbody rb;
 private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    private void Move()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);
    }
    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
           rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }

        
    }
}
