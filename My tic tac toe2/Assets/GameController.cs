using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Material xMaterial; // Reference to X material
    public Material oMaterial; // Reference to O material
    private string currentPlayer = "X"; // Current player
    private GameObject[] cells; // Array for the cells
    private int moveCount = 0; // Count of moves
    private string[] board; // Track the state of the board

    // Start is called before the first frame update
    void Start()
    {
        cells = new GameObject[9];
        board = new string[9];

        for (int i = 0; i < transform.childCount; i++)
        {
            cells[i] = transform.GetChild(i).gameObject;
            cells[i].GetComponent<Renderer>().material.color = Color.white; // Reset color
            cells[i].AddComponent<BoxCollider>(); // Add colliders for clicks
            board[i] = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for mouse click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the clicked object is one of the cells
                for (int i = 0; i < cells.Length; i++)
                {
                    if (hit.transform.gameObject == cells[i])
                    {
                        // Ensure the cell is still white (not already taken)
                        if (hit.transform.gameObject.GetComponent<Renderer>().material.color == Color.white)
                        {
                            // Change the cell's material based on the current player
                            hit.transform.gameObject.GetComponent<Renderer>().material = currentPlayer == "X" ? xMaterial : oMaterial;
                            board[i] = currentPlayer; // Update the board state
                            moveCount++;

                            // Check for win or draw conditions
                            if (CheckForWin())
                            {
                                Debug.Log(currentPlayer + " wins!");
                                ResetGame();
                            }
                            else if (moveCount >= 9)
                            {
                                Debug.Log("It's a draw!");
                                ResetGame();
                            }
                            else
                            {
                                // Switch player
                                currentPlayer = currentPlayer == "X" ? "O" : "X"; // Switch player
                            }
                        }
                        break; // Exit the loop after finding the cell
                    }
                }
            }
        }
    }

    private bool CheckForWin()
    {
        // Winning combinations
        int[,] winningCombinations = new int[,]
        {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 0, 4, 8 },
            { 2, 4, 6 }
        };

        for (int i = 0; i < winningCombinations.GetLength(0); i++)
        {
            if (board[winningCombinations[i, 0]] == currentPlayer &&
                board[winningCombinations[i, 1]] == currentPlayer &&
                board[winningCombinations[i, 2]] == currentPlayer)
            {
                return true;
            }
        }

        return false;
    }

    private void ResetGame()
    {
        moveCount = 0;
        currentPlayer = "X"; // Reset player

        for (int i = 0; i < cells.Length; i++)
        {
            cells[i].GetComponent<Renderer>().material.color = Color.white;
            board[i] = ""; // Reset the board state
        }
    }
}
