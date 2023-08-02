using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFrameSystem : MonoBehaviour
{
    public GameObject Frame;
    private int SelectNum = 0;
    private float delay =0.1f;

    public void SelectText(int Count, bool isEnd)
    {
        
    }
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.UpArrow) && SelectNum != 0)
    //    {
    //        Frame.transform.position = new Vector3(Frame.transform.position.x, Frame.transform.position.y + 50f);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.DownArrow) && SelectNum <= Count)
    //    {
    //        Frame.transform.position = new Vector3(Frame.transform.position.x, Frame.transform.position.y - 50f);
    //        Debug.Log("Test!");
    //    }
    //}
}
