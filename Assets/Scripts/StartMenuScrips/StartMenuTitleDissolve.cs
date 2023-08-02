using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace StartMenu
{
    public class StartMenuTitleDissolve : MonoBehaviour
    {
        public TMP_Text text;
        public float FadeSpeed;

        private void Start()
        {
            Color color = text.color;
            for (int i = 0; i < 150; i++)
            {
                text.DOColor(new Color(color.r, color.g, color.b, 1), FadeSpeed);
            }

        }
    }
}
