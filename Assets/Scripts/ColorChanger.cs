using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class ColorChanger : MonoBehaviour
{
    public TMP_Text textMeshPro;

    public Color succeedColor;
    public Color errorColor;

    private void Start()
    {
        //textMeshPro.color = new Color(0.2f, 0.5f, 0.4f, 0.2f);    
    }

    public void ChangeColorToSucceed(ButtonRomanNumber button)
    {
        Debug.Log("Color changed");
        var initialColorBlock = button.GetComponent<Button>().colors;
        initialColorBlock.normalColor = succeedColor;
        initialColorBlock.pressedColor = succeedColor;
        initialColorBlock.selectedColor = succeedColor;

        button.GetComponent<Button>().colors = initialColorBlock;

        //StartCoroutine(chang(asd));
    }

    private IEnumerator chang(ColorBlock asd)
    {
        yield return new WaitForEndOfFrame();
        asd.normalColor = succeedColor;
        asd.pressedColor = succeedColor;
        asd.selectedColor = succeedColor;

        var colors = GetComponent<Button>().colors;
        colors.normalColor = Color.red;
        GetComponent<Button>().colors = colors;
    }

}
