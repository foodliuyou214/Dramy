using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace StartMenu
{
    public class MenuObjectDissolve : MonoBehaviour
    {
        public GameObject model;
        public float FadeSpeed;
        private List<Material> materials = new List<Material>();

        private void Start()
        {
            DG.Tweening.DOTween.SetTweensCapacity(tweenersCapacity: 2100000, sequencesCapacity: 9000);
            GetMeterials();
            FadeIn();
        }
        private void GetMeterials()
        {
            Material[] materals;
            MeshRenderer[] meshRendererer = model.GetComponentsInChildren<MeshRenderer>();
            foreach (var item in meshRendererer)
            {
                materals = item.materials;
                foreach (Material m in materals)
                {
                    if (!materials.Contains(m))
                    {
                        materials.Add(m);
                    }
                }
            }
            for (int i = 0; i < materials.Count; i++)
            {
                Material m = materials[i];
                m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                m.SetInt("_ZWrite", 0);
                m.DisableKeyword("_ALPHATEST_ON");
                m.EnableKeyword("_ALPHABLEND_ON");
                m.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                m.renderQueue = 3000;
            }
        }

        private void FadeOut()
        {
            for (int i = 0; i < materials.Count; i++)
            {
                Material m = materials[i];
                Color color = m.color;
                m.DOColor(new Color(color.r, color.g, color.b, 0), 3f);
            }
        }

        private void FadeIn()
        {
            for (int i = 0; i < materials.Count; i++)
            {
                Material m = materials[i];
                Color color = m.color;
                m.DOColor(new Color(color.r, color.g, color.b, 1), FadeSpeed);
            }
        }
    }
}

