using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Needed for the UI elements

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; //Forward speed
    public float moveSpeed = 5f; //Sideways movement speed
    public Text scoreText; //UI Text to display score

    private int score = 0; // player's score
    // Start is called before the first frame update
    private Rigidbody rb; //Reference to the Rigidbody component
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Get the Rigidbody component
        UpdateScore(); //Intialize score display
    }

    // Update is called once per frame
    void Update()
    {
      MoveVehicle(); //Call the movement function 
    }
    void MoveVehicle()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //Get horizontal input
        float verticalInput = Input.GetAxis("Vertical"); //Get vertical input

        //Calculate movement direction
        
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;

        //Apply movement
        rb.MovePosition(transform.position + movement);
        
    }
     void UpdateScore() //Method to Update the score
     {
        scoreText.text = "Score:" + score; //Update the score text
     }
     private void OnTriggerEnter(Collider other)
     {
        if(other.CompareTag("Obstacle"))
        {
            score++;
            UpdateScore();
            Destroy(other.gameObject); //Remove the obstacle
        }
     

     }
}
