using UnityEngine;
using TMPro;

public class ColorChanger : MonoBehaviour
{
    public TMP_Text textMeshPro;

    private void Start()
    {
        textMeshPro.color = new Color(0.2f, 0.5f, 0.4f, 0.2f);    
    }
}
