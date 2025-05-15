using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class rollingball : MonoBehaviour
{
    public float speed = 10f;//speed pf thhe sphere
    private Rigidbody rb; //Reference to the rigidbody component
    public  Text scoreText; //Reference to the UI text for score
    private int score = 0; //Player's score

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); //Get the Rigidbody component
       UpdateScoreText(); //Update the score at the start 
    }

    // Update is called once per frame
    void Update()
    {
      //Get input from Horizontal and Vertical axes
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");

      //Create a movement vector
      Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

      //Apply force to the Rigidbody to move yhe sphere
      rb.AddForce(movement*speed);  
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Check if the collided object is tagged as "Cube"
        if(collision.gameObject.CompareTag("Cube"))
        {
            Destroy(collision.gameObject); //Destroy the cube
            score++; // Increment score
            UpdateScoreText();//Update the score display
        }
    }
    void UpdateScoreText()
    {
        scoreText.text = "score"; //Update the score text
    }
}
