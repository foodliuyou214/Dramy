using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectWordGenerator : MonoBehaviour
{
    public TMP_Text Text;
    public void GenerateWord(string text)
    {
        if (text.Length <= 45) 
        {
            Text.text = text;
        }
        else
        {
            Debug.LogError(text + "The string has exceeded the 45-character limit");
        }
    }
}
