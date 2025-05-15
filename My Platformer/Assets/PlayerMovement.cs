using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded; // Check if the player is on the ground
    // Start is called before the first frame update
     void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(); //Call the move method to handle movement
        Jump(); //Call the move method to handle jumping
    }
    private void Move()
     {
        //Get input from the horizontal and vertical axes
      float moveHorizontal = Input.GetAxis("Horizontal"); //A/D or Left/Right arrows
       float moveVertical = Input.GetAxis("Vertical"); //W/S or Up/Down arrows
      //Create a movement vector
       Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
       //Apply the movement to the player
       rb.MovePosition(Transform.position + movement * moveSpeed * Time.deltaTime);

       private void Jump()
       // Check if the jump button is pressed and if the player is grounded
        if( Input.GetButtonDown("Jump") && isGrounded)
        {
       rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Apply jump force
        } 
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Check if the player has collided with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; //Set isGrounded to true
        }
    }
    private void OncollisionExit(Collision collision)

    {//check if player has colleded with the ground
       if (collision.gameObject.CompareTag("Ground")) 
       {
        isGrounded = false; // Set is ground false
       }
    }
}
