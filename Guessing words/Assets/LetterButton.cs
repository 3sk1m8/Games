using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterButton : MonoBehaviour
{
    public char letter;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnLetterClicked);
        button.GetComponentInChildren<Text>().text = letter.ToString();
    }

    // Update is called once per frame
    void OnLetterClicked()
    {
       //Add letter to word input
       WordInput.Instance.AddLetter(letter); 
    }
}
