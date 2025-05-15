using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Need for UI elements

public class GameController : MonoBehaviour
{
    public Text scoreText; //This should be public
    private int score = 0;
    // Start is called before the first frame update
    public CoinController coin; //Drag your coin GameObject here in Inspector
    void Start()
    {
       // Find the score text by its name
       scoreText = GameObject.Find("YourScoreTextName").GetComponent<Text>();
       score = 0;
       UpdateScore();
    }

    private void UpdateScore()
{
    scoreText.text = "Score:" + score.ToString();
}
 public void IncreaseScore( int amount)
 {
    score += amount;
    UpdateScore();
 }
 public void OnPlayButtonClicked()
 {
    //Explain direction to move the coin upward
    Vector3 direction = new Vector3(0, 5, 0);
    coin.MoveCoin(direction);
 }
}
