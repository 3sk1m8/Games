using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 2f; //Speed of tthe platform movement
    public float moveDistance = 5f; //Distance to move side to side

    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
      startPosition = transform.position; //Store the starting position  
    }

    // Update is called once per frame
    void Update()
    {
       float newPosition = Mathf.PingPong(Time.time * speed, moveDistance) - (moveDistance / 2);
       transform.position = new Vector3(startPosition.x + newPosition, starPosition.y, startPosition.z); 
    }
}
