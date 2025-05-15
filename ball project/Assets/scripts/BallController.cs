using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Needed for scene management

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, speed); //Adjust the intial velocity
    }
     void Update()
     {
        //Check if the ball falls below a certain Y position
        if (transform.position.y < -6)
        {
            GameOver();
        }
     }
     private void GameOver()
     {
        //Reset the game or load the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }
    // Update is called once per frame
    private void OnCollisionEnter2d(Collision2D, collision)
    {
      if (collision.gameObject.CompareTag("Brick"))
    {
      Destroy(collision.gameObject);  
    }
    }
}
