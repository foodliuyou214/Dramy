using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;

public class DialogSystem : MonoBehaviour
{
    public DialogConfig dialogConfig;
    public GameObject gameObj;
    public TMP_Text Text;
    private string tmp_Text;
    public float delay = 0.1f;
    private string currentText;
    internal bool isSkip;
    public void DialogText(string Id, int index)
    {
        for (int i = 0; i < dialogConfig.DialogContents.Count; i++)
        {
            if (dialogConfig.DialogContents[i].ID == Id)
            {
                tmp_Text = dialogConfig.DialogContents[i].DialogContent[index].Content;
                string tmp_name = dialogConfig.DialogContents[i].Name + ":";
                StartCoroutine(ShowText(tmp_name,i,index,Id));
                
            }
        }

    }

    public IEnumerator ShowText(string name, int j, int index, string id)
    {
        for (int i = 0; i <= tmp_Text.Length; i++)
        {
            if (!isSkip)
            {
                currentText = tmp_Text[..i];
                GetComponent<TMP_Text>().text = name + currentText;
                yield return new WaitForSeconds(delay);
            }
        }
        GameObject.FindWithTag("Player").GetComponent<RayDetectionObjects>().IsPressE = false;
        if (dialogConfig.DialogContents[j].DialogContent[index].Chooses.Count != 0)
        {
            GameObject.FindWithTag("SelectGenerator").
                GetComponent<SelectGenerator>().Generate
                (dialogConfig.DialogContents[j].DialogContent[index].Chooses.Count - 1);
            for (int i = 0; i < dialogConfig.DialogContents[j].DialogContent[index].Chooses.Count; i++)
            {

                GameObject[] tmp_Obj = GameObject.FindGameObjectsWithTag("SelectGeneratorParent");
                for (int k = 0; k < tmp_Obj.Length; k++)
                {
                    tmp_Obj[k].GetComponent<SelectIDAndGenerateText>().Generator(id, index);
                }
            }

        }
    }
}
