using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    private BouncingBallGame gamemanager;
    // Start is called before the first frame update
    void Start()
    {
      gameManager = GameObject.Find("GameController").GetComponent<BouncingBallGame>();  
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.GameObject.name == "Ball")
        {
            gameManager.knockDownBlock(gameObject); //Notify game manager to knock down the block
        }
    }
}
