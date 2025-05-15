using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public GameObject snakeSegmentPrefab;
    public GameObject ballPrefab;
    public float moveSpeed = 5f;
    private List<Transform> snakeSegments = new List<Transform>(); // Changed variable name to snakeSegments
    private Vector3 direction = Vector3.right; // Initial direction
    private Rigidbody ballRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        // Create initial snake segment
        AddSnakeSegment();
        // Create and position the ball
        GameObject ball = Instantiate(ballPrefab, new Vector3(0, 0.5f, 0), Quaternion.identity);
        ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        MoveSnake();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) direction = Vector3.forward;
        if (Input.GetKeyDown(KeyCode.DownArrow)) direction = Vector3.back;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) direction = Vector3.left;
        if (Input.GetKeyDown(KeyCode.RightArrow)) direction = Vector3.right;
    }
void MoveSnake()
{
    if (snakeSegments.Count > 0)
    {
        // Move the snake segments
        Vector3 newPosition = snakeSegments[0].position + direction * moveSpeed * Time.deltaTime;
        for (int i = snakeSegments.Count - 1; i > 0; i--)
        {
            snakeSegments[i].position = snakeSegments[i - 1].position;
        }
        snakeSegments[0].position = newPosition;

        // Check if the snake is pushing the ball
        if (Vector3.Distance(snakeSegments[0].position, ballRigidbody.transform.position) < 1f)
        {
            ballRigidbody.AddForce(direction * moveSpeed, ForceMode.Impulse);
        }
    }
}
  void AddSnakeSegment()
{
    GameObject newSegment = Instantiate(snakeSegmentPrefab);

    if (snakeSegments.Count > 0)
    {
        // Position the new segment behind the last segment
        Transform lastSegment = snakeSegments[snakeSegments.Count - 1];
        newSegment.transform.position = lastSegment.position - new Vector3(1, 0, 0);
    }
    else
    {
        newSegment.transform.position = new Vector3(0, 0.5f, 0);
    }

    snakeSegments.Add(newSegment.transform);
}

}
