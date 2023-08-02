using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace StartMenu
{
    public class StartMenuCubeGenerator : MonoBehaviour
    {
        public GameObject GeneratorObjects;
        public float PosRX1, PosRX2, PosRY1, PosRY2, PosRZ1, PosRZ2;
        public float RotRX1, RotRX2, RotRY1, RotRY2, RotRZ1, RotRZ2;
        public float LScRX1, LScRX2, LScRY1, LScRY2, LScRZ1, LScRZ2;
        public int GenerateCount;


        private void Start()
        {


            for (int i = 0; i < GenerateCount; i++)
            {

                GameObject CloneObjects = Instantiate(GeneratorObjects);

                float PosX = Random.Range(PosRX1, PosRX2);
                float PosY = Random.Range(PosRY1, PosRY2);
                float PosZ = Random.Range(PosRZ1, PosRZ2);
                float RotX = Random.Range(RotRX1, RotRX2);
                float RotY = Random.Range(RotRY1, RotRY2);
                float RotZ = Random.Range(RotRZ1, RotRZ2);
                float LScX = Random.Range(LScRX1, LScRX2);
                float LScY = Random.Range(LScRY1, LScRY2);
                float LscZ = Random.Range(LScRZ1, LScRZ2);

                CloneObjects.transform.SetPositionAndRotation(new Vector3(PosX, PosY, PosZ), Quaternion.Euler(RotX, RotY, RotZ));
                CloneObjects.transform.localScale = new Vector3(LScX, LScY, LscZ);
            }
        }

    }
}
