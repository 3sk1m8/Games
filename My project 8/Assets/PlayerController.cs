using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI; //Include for the UI elements
public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f; //Force applied when jumping
    public float moveSpeed = 5f; //Speed of sideways movement
    private Rigidbody rb;
    // Start is called before the first frame update
    public Text scoreText; //UI Text to display score
    private int score = 0; //Player's score
    void Start()
    {
      rb = GetComponent<Rigidbody>();  
      UpdateScoreText(); //Update the score text at the start
    }
    void Update()
    {
        Move(); // Handle movement
        if(Input.GetKeyDown(KeyCode.Space)) //Jump when the Spacebar pressed
        
        {
            Jump();
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //Get horizontal input (A/D or Left/Right)
        float moveVertical = Input.GetAxis("Vertical"); //Get vertical input (W/S or Up/Down)
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical); //Create movement vector
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, rb.velocity.z * moveSpeed);//Apply movement
    }
    void Jump()
    {
        //Check if the capsule is grounded before jumping
        if(IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z); //Set the Y velocity to jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }
    private bool IsGrounded()
    {
        //Check if the capsule is touching the ground
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    

    }
    private void OnTriggerEnter( Collider other)
    {
        if (other.CompareTag("ScoreCube")) //Check if it collided with a scoring object
        {
            score++;
            UpdateScoreText();
            Destroy(other.gameObject); //Remove the scored cube
        }
        else if(other.CompareTag("Obstacle")) //Check if it collided with an obstacle
        {
            Debug.Log("Game Over!"); //Reset position or handle game over
            transform.position = new Vector3(0, 1, 0); //Reset to starting position
            score = 0; //Reset score
            UpdateScoreText(); //Update score display
        }
    }
    void UpdateScoreText()
    {
        scoreText.text = "Score:" + score; //Update the score display
    }
    
}
