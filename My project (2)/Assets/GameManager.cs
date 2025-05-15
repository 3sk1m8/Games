using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ public GameObject car; // Reference to the car GameObject
public Text scoreText; //Reference to the score text
private int score = 0;
    // Start is called before the first frame update
   private void Start()
    {
      scoreText.text = "Score:" + score;
      car.SetActive(false); //Hide the car initially  
    }

    // Update is called once per frame
   public  void StartGame()
    {
        score = 0;
        scoreText.text = "Score:" + score;
        car.SetActive(true);
    }
    private void Update()
    {
        if(car.activeSelf) // Update sore only if the car is active
        {
            score += (int)(Time.deltaTime * 10);//Increament score based on time
            scoreText.text = "Score:" + score;
        }
        
    }

}
