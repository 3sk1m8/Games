using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordInput : MonoBehaviour
{
    public static WordInput Instance;
    public Text inputFieldText;
    // Start is called before the first frame update
    private void Awake()
    {
       Instance = this; 
    }

    // Update is called once per frame
  public  void AddLetter(Char letter)
    {
      inputFieldText.text += letter; //Append letter to the input field  
    }

    public void SubmitWord()
    {
        //Check if the formed word is valid
        //Reset input field
        inputFieldText.text = "";
    }
}
