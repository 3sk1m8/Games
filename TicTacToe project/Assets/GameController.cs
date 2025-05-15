using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Button[] buttons; // Array for the buttons
    private string currentPlayer = "X"; // current player
    private int movecount = 0; //Count of moves
    // Start is called before the first frame update
    void Start()
    {
       //Add listeners to buttons
       foreach (Button button in buttons)
       {
        button.onClick.AddListener(() => OnButtonClick(button));
       } 
    }

    // Update is called once per frame
    void OnButtonClick(Button button)
    {
       if(button.GetComponentInChildren<Text>().text =="")
       {
        button.GetComponentInChildren<Text>().text = currentPlayer;
        movecount++;
        if(CheckForWin())
        {
            Debug.Log(currentPlayer + "wins!");
            ResetGame();
        }
        else if (movecount >= 9)
        {
            Debug.Log("It's a draw!");
            ResetGame();
        }
        else
        {
            currentPlayer = currentPlayer == "X" ? "O" : "X"; //Switch player       
        }
       } 
       bool CheckForWin()
       {
        //List winning combinations
        List<int[]> winningCombinations = new List<int[]>{
            new int[] {0, 1, 2},
            new int[] {3, 4, 5},
            new int[] {6, 7, 8},
            new int[] {0, 3, 6},
            new int[] {1, 4, 7},
            new int[] {2, 5, 8},
            new int[] {0, 4, 8},
            new int[] {2, 4, 6}
         };
         foreach (var combination in winningCombinations)
         {
            if(buttons[combination[0]].GetComponentInChildren<Text>().text == currentPlayer &&
               buttons[combination[1]].GetComponentInChildren<Text>().text == currentPlayer &&
               buttons[combination[2]].GetComponentInChildren<Text>().text == currentPlayer)
               {
                return true;
               }
         }
         return false;
       }
       void ResetGame()
       {
        foreach (Button button in buttons)
        {
            button.GetComponentInChildren<Text>().text = "";
        }
        movecount = 0;
        currentPlayer = "X"; //Reset to player X
       }
    }
}
cells[winningCombinations[i, 0]].GetComponent<Renderer>().material.color == 
        (currentPlayer == "X" ? Color.red : Color.blue) &&
        cells[winningCombinations[i ,1]].GetComponent<Renderer>().material.color ==
        (currentPlayer == "X" ? Color.red : Color.blue) &&
        cells[winningCombinations[i, 2]].GetComponent<Renderer>().material.color ==
        (currentPlayer == "X" ? Color.red : Color.blue))

         foreach (GameObject cell in cells)
        {
            cell.GetComponent<Renderer>().material.color = Color.white; //Reset color
        }
        moveCount = 0;
        currentPlayer = "X"; //Reset to playe