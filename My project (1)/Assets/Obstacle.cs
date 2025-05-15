using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{ 
    public float moveSpeed = 3f;
    private bool isMoving = false;

    void Update()
    {
        if(isMoving)
        {
        
        //Move the obstacle towards the player (assuming the player is at the origin)
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider other)
{
    if(other.CompareTag("Player"))
    {
      //Start moving when player collides with obstacle
      isMoving = true;
      
    }
}
   void OnTriggerExit(Collider other)

   {
    if (other.CompareTag("Player"))
   
   {
     // stop moving when the player leaves the obstacle
     isMoving = false;
   }
   }
}
