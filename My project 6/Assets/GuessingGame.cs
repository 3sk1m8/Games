using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessingGame : MonoBehaviour
{
    public Text instructionText; // Reference to the UI text for instructions
    public InputField guessInputField; // Reference to the InputField for guesses
    public Button submitButton; // Reference to the submit button

    private int numberToGuess; // The number to guess
    private int attempts; // Number of attempts made

    // Start is called before the first frame update
    void Start()
    {
        StartNewGame();
        submitButton.onClick.AddListener(CheckGuess);
    }

    void StartNewGame()
    {
        numberToGuess = Random.Range(1, 101); // Random number between 1 and 100
        attempts = 0;
        instructionText.text = "Guess a number between 1 and 100";
        guessInputField.text = ""; // Clear the input field
    }

    void CheckGuess()
    {
        int playerGuess;
        if (int.TryParse(guessInputField.text, out playerGuess))
        {
            attempts++;
            if (playerGuess > numberToGuess)
            {
                instructionText.text = "Too high! Try again.";
            }
            else if (playerGuess < numberToGuess)
            {
                instructionText.text = "Too low! Try again.";
            }
            else
            {
                instructionText.text = $"Congratulations! You've guessed the correct number {numberToGuess} in {attempts} attempts.";
                StartNewGame(); // Restart the game
            }
        }
        else
        {
            instructionText.text = "Please enter a valid number.";
        }
    }
}
