using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; //Speed of the sphere
    private Rigidbody rb; //Reference to the Rigidbody component

    private Vector3 startPosition; //Starting position of the sphere
    public float maxDistance = 5f; //Maximum distance the sphere can roll
     void Start()
    {
      rb = GetComponent<Rigidbody>();// Get the Rigidbody component 
      startPosition = transform.position; // Store the starting position
    }
    void Update()
    {
        // Calculate the distance from the starting position
        float distance = Vector3.Distance (startPosition, transform.position);
      // Get input from Horizontal and Vertical axes
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");
      Debug.Log($"Horizontal :{moveHorizontal}, Vertical: {moveVertical}");
      //Create a movement vector
      Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

      //Applly force to the Rigidbody to move the sphere
      if (distance < maxDistance)
      {
      rb.AddForce(movement*speed);  
    }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Check if the collied object is tagged as "Cube"
        if (collision.gameObject.CompareTag("Cube"))
        {
            Destroy(collision.gameObject); //Destroy the cube
            Debug.Log("Cube knocked off!"); //Log message
        }
    }
}
