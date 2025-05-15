using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum Choice { Rock, Paper, Scissors }
    public Choice playerChoice;
    public Choice computerChoice;
    public Text resultText; //Reference to the UI Text for displaying results

    // Assign these methods to UI buttons
    public void ChooseRock()
    {
        playerChoice = Choice.Rock;
        PlayGame();
    }
    public void ChoosePaper()
    {
        playerChoice = Choice.Paper;
        PlayGame();
    }
    public void ChooseScissors()
    {
        playerChoice = Choice.Scissors;
        PlayGame();
    }

    void PlayGame()
    {
        // Generate computer choice
        computerChoice = (Choice)Random.Range(0, 3);

        // Determine the winner
        string result = DetermineWinner();

        // Display result
        DisplayResult(result);
    }

    string DetermineWinner()
    {
        if (playerChoice == computerChoice)
        {
            return "It's a tie!";
        }
        else if ((playerChoice == Choice.Rock && computerChoice == Choice.Scissors) ||
                 (playerChoice == Choice.Scissors && computerChoice == Choice.Paper) ||
                 (playerChoice == Choice.Paper && computerChoice == Choice.Rock))
        {
            return "Player wins!";
        }
        else
        {
            return "Computer wins!";
        }
    }

    void DisplayResult(string result)
    {
        resultText.text = $"Player choice: {playerChoice}, Computer choice: {computerChoice}\n{result}";
    }
}
