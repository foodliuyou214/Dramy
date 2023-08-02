using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StartMenu
{
    public class StartMenuCameraLoad : MonoBehaviour
    {
        public Transform Camera;
        float i = 0f;
        private void FixedUpdate()
        {
            if (Camera.position.y < 2.11f)
            {
                Camera.position = new Vector3(Camera.position.x, Camera.position.y + i, Camera.position.z);
                i += 0.0005f;
            }

        }
    }
}
