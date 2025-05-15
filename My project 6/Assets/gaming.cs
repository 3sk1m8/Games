using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guessinggame : MonoBehaviour

{
        public Text instructionText; // Reference tu the UI text for instructions
    public InputField guessInputField; //Reference to the InputField for guesses
    public Button submitButton; //Referce to the submit button

    private int; //The number to guess

    private int attempts; //number of attempts made

    // Start is called before the first frame update
    void Start()
    {
        startNewGame();
        submitButton.onClick.Addlistener(checkGuess);
    }
void startNewGame()
{
    numberToGuess=To Random.Range(1,101); //Random number between 1 and 100
    attempts=0;
    InstructionText.text="Guess a number between 1 and 100";
    guessInputField.text="";// Clear the inputfield
}
void CheckGuess()
      {
        int playerGuess;
        if (int.TryParse(guessInputField.Text , out playerGuess))
        {
            attempts ++;
            if( playerGuess > numberToGuess)
            {
                instructionText.text = "Too high! Try again";
            }
            else if 
            {
              instructionText.text = "Too low! Try again";
            }
        else
        {
            InstructionText.text = $"Cogratulations! You have guessed the correct number{numberToGuess} in {attempts} attempts";
        
        StartNewGame ();//Restart the Game
        }
        }
        else
        {
            insrtuction.Text.text ="Please enter a valid number"
        }
        
        }
      }
   