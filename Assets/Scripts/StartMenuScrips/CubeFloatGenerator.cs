using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StartMenu
{
    public class CubeFloatGenerator : MonoBehaviour
    {
        private float radian = 0;
        private float perRadian = 0.03f;
        private float radius = 0.05f;
        private Vector3 oldPos;
        public bool disabledRot;
        public float AnglesChangeSpeed;
        public float PosChangeSpeed;

        void Start()
        {
            oldPos = transform.position;
        }

        void Update()
        {
            radian += perRadian;
            float dy = Mathf.Sin(radian) * radius * PosChangeSpeed;
            transform.position = oldPos + new Vector3(0, dy, 0);
            if (disabledRot == false)
                transform.localEulerAngles += new Vector3(0, AnglesChangeSpeed * Random.Range(0.1f, 2f), 0);
        }
    }
}
