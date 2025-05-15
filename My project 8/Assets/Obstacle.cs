using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 2f; //Speed at which the obstacle moves
    public Vector3 moveDirection = Vector3.forward; //Direction of movement


    // Update is called once per frame
    void Update()
    {
       MoveObstacle(); //Call the movement method each frame 
    }
    void MoveObstacle()
    {
        //Move the obstacle in the specified direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) //Check if the player capsule collided with obstacle
        {
            Debug.Log("Player hit obstacle");  // The player scores one point
             
        }
    }
}
