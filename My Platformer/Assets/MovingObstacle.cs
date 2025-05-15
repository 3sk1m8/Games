using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 3f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
      startPosition = transform.position;
      targetPosition =  startPosition + new Vector3(moveDistance, 0, 0); // Move along the X-axis 
    }

    // Update is called once per frame
    void Update()
    {
        // Move the obstacle back and forth
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        //Check if we've reached the target position
        if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Swap the target position
            targetPosition = targetPosition == startPosition ? startPosition + new Vector3(moveDistance, 0, 0) : startPosition;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle collision with the player
            Debug.Log("Player hit the moving obstacle!");
        }
    }
}
