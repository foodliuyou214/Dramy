using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StartMenu
{
    public class StartMenuSceneTransition : MonoBehaviour
    {
        float i = 0f;
        float j = 0f;
        bool Is = false;
        public Transform ChangeTransitionLight;
        public Transform CameraPos;
        public int SceneCount;
        private void Update()
        {
            if (CameraPos.position.y >= 72)
            {
                if (ChangeTransitionLight.position.z > -6.5f && Is == false)
                {
                    ChangeTransitionLight.position = new Vector3
                        (
                        ChangeTransitionLight.position.x,
                        ChangeTransitionLight.position.y,
                        ChangeTransitionLight.position.z - i
                        );
                    i += 0.00001f;
                    if (ChangeTransitionLight.position.z <= -6.5f)
                    {
                        Is = true;
                    }
                }
                else if (Is)
                {
                    ChangeTransitionLight.position = new Vector3
                        (
                        ChangeTransitionLight.position.x,
                        ChangeTransitionLight.position.y,
                        ChangeTransitionLight.position.z + j
                        );
                    j += 0.0001f;
                    if (ChangeTransitionLight.position.z > 3f)
                    {
                        SceneManager.LoadScene(SceneCount);
                    }
                }
            }
        }
    }
}
