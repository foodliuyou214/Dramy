using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectIDAndGenerateText : MonoBehaviour
{
    public int ID;
    public DialogConfig dialogConfig;
    public GameObject gameObj;
    private GameObject c1;
    public void Generator(string Id, int index)
    {
        for (int i = 0; i < dialogConfig.DialogContents.Count; i++)
        {
            if (dialogConfig.DialogContents[i].ID == Id)
            {
                //GameObject.FindWithTag("SelectTextGenerator")
                for (int j = 0; j < gameObj.transform.childCount; j++)
                {
                    c1 = gameObj.transform.GetChild(j).gameObject;
                }
                c1.GetComponent<SelectWordGenerator>().GenerateWord(
                    dialogConfig.DialogContents[i].DialogContent[index].Chooses[ID]);
                
            }
        }

    }
}

