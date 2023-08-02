using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Game/Interaction/DialogConfig")]
public class DialogConfig : ScriptableObject
{
    public List<Dialog> DialogContents = new List<Dialog>();
}


[System.Serializable]
public class Dialog
{
    public string Name;
    public string ID;
    
    public List<Choose> DialogContent = new List<Choose>();
}

[System.Serializable]
public class Choose
{
    [TextArea(1, 3)] public string Content;
    public List<string> Chooses = new List<string>();
}