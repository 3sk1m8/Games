using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int points = 1; //Points awarded for destroying thiis brick
    private GameController GameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectofType<GameController>(); //Find the GameController in the scene
    }
    private void ONCollisionEnter2D(Collision2D collision)
    {
        //Check if the ball hits the brick
        if (collision.gameObject.CompareTag("Ball"))
        {
            gameController.AddScore(points); //Add score
            Destroy(gameObject); //Destroy the brick
        }
    }

}
