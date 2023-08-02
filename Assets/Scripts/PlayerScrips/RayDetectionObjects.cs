using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class RayDetectionObjects : MonoBehaviour
{
    public Camera RayCamera;
    internal GameObject gameObj;
    private bool IsTrigger;
    private bool isShowInfo;
    public string Info;
    private bool IsDialogShow;
    internal int DialogIndex;
    internal bool IsPressE;
    internal bool IsEnd;
    public DialogConfig dialogConfig;

    //public int tmpi = 0;

    private GameObject c1;



    void Start()
    {
        DialogIndex = 0;
        isShowInfo = false;
        IsDialogShow = false;
    }
    void Update()
    {
        if (!IsDialogShow)
        {
            GameObject.FindWithTag("Dialog").GetComponent<Image>().enabled = false;
            GameObject.FindWithTag("DialogText").GetComponent<TMP_Text>().enabled = false;
        }
        Ray ray = RayCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Debug.DrawLine(ray.origin, hitInfo.point);
            gameObj = hitInfo.collider.gameObject;
            Info = gameObj.name;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (IsTrigger)
                {
                    if (gameObj.CompareTag("CollectObject"))
                    {
                        Debug.Log(gameObj.name + " +1");
                        Destroy(gameObj);
                    }
                    else if (gameObj.CompareTag("InteractionObject"))
                    {
                        IsDialogShow = true;
                        IsEnd = true;
                        if (IsDialogShow)
                        {
                            GameObject.FindWithTag("Dialog").GetComponent<Image>().enabled = true;
                            GameObject.FindWithTag("DialogText").GetComponent<TMP_Text>().enabled = true;
                        }
                        if (!IsPressE)
                        {
                            IsPressE= true;
                            for (int i = 0; i < GameObject.FindWithTag("DialogText").GetComponent<DialogSystem>().dialogConfig.DialogContents.Count; i++)
                            {
                                if (GameObject.FindWithTag("DialogText").GetComponent<DialogSystem>().dialogConfig.DialogContents[i].ID == gameObj.GetComponent<ID>().Id)
                                {
                                    if (DialogIndex < GameObject.FindWithTag("DialogText").GetComponent<DialogSystem>().dialogConfig.DialogContents[i].DialogContent.Count)
                                    {
                                        IsEnd = false;
                                        #region Skip
                                        //if (tmpi>1)
                                        //{
                                        //DialogIndex--;
                                        //GameObject.FindWithTag("DialogText").GetComponent<DialogSystem>().TextLoad(gameObj.GetComponent<ID>().Id, DialogIndex);
                                        //tmpi = 0;
                                        //}
                                        //else 
                                        //{
                                        //GameObject.FindWithTag("DialogText").GetComponent<DialogSystem>().isSkip = false;

                                        //tmpi++;
                                        //}
                                        #endregion
                                        GameObject.FindWithTag("DialogText").GetComponent<DialogSystem>().DialogText(gameObj.GetComponent<ID>().Id, DialogIndex);

                                                GameObject.FindWithTag("SelectFrame").GetComponent<SelectFrameSystem>().
                                                    SelectText(GameObject.FindWithTag("DialogText").
                                                    GetComponent<DialogSystem>().dialogConfig.DialogContents[i].DialogContent[DialogIndex].Chooses.Count,IsEnd);

                                        






                                        DialogIndex++;
                                    }
                                    else
                                    {
                                        DialogIndex = 0;
                                        IsPressE = false;
                                        IsDialogShow = false;
                                    }
                                }
                            }
                        }
                        else
                        {

                        }
                    }
                        

                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectObject"))
        {
            isShowInfo = true;
            ShowObjName();
            IsTrigger = true;
        }
        else if (other.CompareTag("InteractionObject"))
        {
            isShowInfo = true;
            IsDialogShow = true;
            ShowObjName();
            IsTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CollectObject"))
        {
            isShowInfo = false;
            HideObjName();
            IsTrigger = false;
        }
        else if (other.CompareTag("InteractionObject"))
        {
            isShowInfo = false;
            IsDialogShow = false; 
            DialogIndex = 0;
            IsPressE = false;
            HideObjName();
            IsTrigger = false;
        }
    }

    private void ShowObjName()
    {
        if (isShowInfo)
        {
            for (int i = 0; i < gameObj.transform.childCount; i++)
            {
                c1 = gameObj.transform.GetChild(i).gameObject;
            }
            c1.GetComponent<TextConfig>().Show();
        }

    }
    private void HideObjName()
    {
        if (!isShowInfo)
        {
            for (int i = 0; i < gameObj.transform.childCount; i++)
            {
                c1 = gameObj.transform.GetChild(i).gameObject;
            }
            c1.GetComponent<TextConfig>().Hide();
        }
    }



}


