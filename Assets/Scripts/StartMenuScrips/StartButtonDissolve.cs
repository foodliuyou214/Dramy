using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using StartMenu;
namespace StartMenu
{
    public class StartButtonDissolve : MonoBehaviour
    {
        public GameObject Camera;
        public Text text;
        public float FadeSpeed;
        public int DegreeOfChange;
        private void Update()
        {
            if (text.color.a >= DegreeOfChange/100)
            {
                Camera.GetComponent<LoadingCameraMove>().IsEndDissolve = true;
            }
            Color color = text.color;
            text.DOColor(new Color(color.r, color.g, color.b, 1), FadeSpeed);

        }

    } 
}
