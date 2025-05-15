using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPool : MonoBehaviour
{
public List<char> letters = new List<char> {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};//Add more letters
public List<char> selectedLetters;
    // Start is called before the first frame update
    void Start()
    {
      GenerateLetters();  
    }

    // Update is called once per frame
    void GenerateLetters()
    {
        selectedLetters = new List<char>();
        for (int i = 0; <                                                                                                                                                                              8; i++)                                                                                                                                          
        {
            selectedLetters.Add(letters[Random.Range(0,letters.Count)]);
        }
    }
}
