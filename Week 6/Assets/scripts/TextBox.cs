using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    public Text textComp;
    private string curText;
    public List<string> textLines;

    // Start is called before the first frame update
    void Start()
    {
        textComp = GetComponent<Text>();
    }

    public void NewMessage(string message)
    {
        //check if we already have 4 lines
        if(textLines.Count >= 4)
        {
            //if so, make some room for a new line
            textLines.RemoveAt(0);
        }
        // "\n" creates a new line
        textLines.Add(message + "\n");
        //reset our curText value
        curText = "";
        //add each of our textLines to our curText variable
        for(int i = 0; i < textLines.Count; i++)
        {
            curText += textLines[i];
        }
        textComp.text = curText;
    }
}
