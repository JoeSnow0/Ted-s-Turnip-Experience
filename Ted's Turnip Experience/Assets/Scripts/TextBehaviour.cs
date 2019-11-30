using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBehaviour : MonoBehaviour
{
    GameController mGameController;
    Text mTextPrefab;
    List<Text> listOfTextCanvases = new List<Text>();

    
    void SendStringToTextCanvas(string text, Text textCanvas)
    {
        textCanvas.text = text;
    }
    void AddNewTextCanvasToList()
    {
        Text newText = Instantiate(mTextPrefab);
        listOfTextCanvases.Add(newText);
    }
    void AddExistingTextCanvasToList(Text newText)
    {
        listOfTextCanvases.Add(newText);
    }
    void RemoveNewTextCanvasToList(Text oldText)
    {
        listOfTextCanvases.Remove(oldText);
    }
}
