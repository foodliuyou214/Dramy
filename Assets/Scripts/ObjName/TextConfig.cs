using UnityEngine;
using TMPro;

public class TextConfig : MonoBehaviour
{
    public GameObject Obj;
    public Camera Player;
    private TMP_Text Text;
    private void Update()
    {
        Text = GetComponent<TMP_Text>();
        Text.text = transform.parent.name;
        var rotation = Quaternion.LookRotation(Player.transform.TransformVector(Vector3.forward),
            Player.transform.TransformVector(Vector3.up));
        rotation = new Quaternion(0, rotation.y, 0, rotation.w);
        gameObject.transform.rotation = rotation;


    }
    public void Show()
    {
        Obj.SetActive(true);
    }
    public void Hide()
    {
        Obj.SetActive(false);
    }
}
