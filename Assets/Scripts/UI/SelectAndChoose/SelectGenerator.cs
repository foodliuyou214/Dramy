using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGenerator : MonoBehaviour
{
    public GameObject SelectPrefab;
    public GameObject SelectFrame;
    public GameObject CloneObjectsLocation;
    private int tmp_ID;
    public void Generate(int count)
    {
        tmp_ID = 0;
        GameObject CloneFramme = Instantiate(SelectFrame);
        CloneFramme.transform.SetParent(CloneObjectsLocation.transform, false);
        CloneFramme.transform.position = new Vector3(725f, 0f + 185f, 0);
        for (int i = 0; i <= count; i++)
        {
            GameObject CloneObjects = Instantiate(SelectPrefab);
            CloneObjects.GetComponent<SelectIDAndGenerateText>().ID= tmp_ID;
            CloneObjects.transform.SetParent(CloneObjectsLocation.transform, false);
            CloneObjects.transform.position = new Vector3(725f, -40 - ((i - 1) * 40) + 185f, 0);
            tmp_ID++;
        }
    }
}
