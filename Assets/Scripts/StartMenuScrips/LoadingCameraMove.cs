using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StartMenu
{
    public class LoadingCameraMove : MonoBehaviour
    {
        public float TargetY;
        public Transform Camera;
        float i = 0f;
        public bool IsBegining;
        public bool IsEndDissolve;
        
        private void FixedUpdate()
        {
            if (Camera.position.y < TargetY && IsBegining && IsEndDissolve)
            {
                Camera.position = new Vector3(Camera.position.x, Camera.position.y + i, Camera.position.z);
                i += 0.0005f;
            }

        }
        public void Begin()
        {
            IsBegining = true;
        }
    }
}
