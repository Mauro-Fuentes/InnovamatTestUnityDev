using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Change the color of the button. Either Succeed or Error
/// </summary>
public class ColorChanger : MonoBehaviour
{
    [Header("Choose colors to display")]
    public Color succeedColor;
    public Color errorColor;

    private void Start()
    {
        
    }

    public void ChangeColorToSucceed(ButtonRomanNumber button)
    {
        Debug.Log("Color changed");
        var initialColorBlock = button.GetComponent<Button>().colors;
        initialColorBlock.normalColor = succeedColor;
        initialColorBlock.pressedColor = succeedColor;
        initialColorBlock.selectedColor = succeedColor;

        button.GetComponent<Button>().colors = initialColorBlock;
    }

    public void ChangeColorToError(ButtonRomanNumber button)
    {
        Debug.Log("Color changed");
        var initialColorBlock = button.GetComponent<Button>().colors;
        initialColorBlock.normalColor = errorColor;
        initialColorBlock.pressedColor = errorColor;
        initialColorBlock.selectedColor = errorColor;

        button.GetComponent<Button>().colors = initialColorBlock;
    }

}
