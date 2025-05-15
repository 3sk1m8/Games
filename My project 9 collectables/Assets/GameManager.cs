using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public Text scoreText;

    public void Awake()
    {
        //Ensure only one instance of the GameManager exists
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep it across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
  public  void Start()
    {
      UpdateScoreText();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        if(scoreText != null)
        {
            scoreText.text = "Score:" + score.ToString();
        }
    }

}
