using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBallGame : MonoBehaviour
{
public GameObject ball;
public Gameobject[] blocks; //Array of blocks
private innt blockCount;

    // Start is called before the first frame update
    void Start()
    {
       blockCount = blocks.Length; //Initialize block count 
    }

    // Update is called once per frame
    void Update()
    {
      if(ball.transform.posistion.y <= -5) //Reset ball position if it falls down 
      {
    ResetBall();
      }
    }
    public void knockDownBlock(GameObject)
    {
        block.SetActive(false); //Disable the block
        blockCount --;

        if (blockCount <= 0)
        {
            Debug.Log("All blocks knocked down!");
            //Add logic for winning or restarting the game
        }
    }
    private void ResentBall()
    {
        ball.transform.position = new Vector2(0,0); //Reset ball position
        ball.GetComponent<Rigidbody2D>.velocity2.zero; //Reset velocity
    }
}

