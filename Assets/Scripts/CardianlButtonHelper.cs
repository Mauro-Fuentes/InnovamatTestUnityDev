using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Change the color of the button. Either Succeed or Error
/// </summary>
public class CardianlButtonHelper : MonoBehaviour
{
    [Header("Choose colors to display")]
    public Color succeedColor;
    public Color errorColor;
    public Color normalColor;

    private ButtonCardinalNumber[] allButtons;

    private void Start()
    {
        
    }

    public void Initialise(ButtonCardinalNumber[] romanButtons)
    {
        allButtons = romanButtons;
    }

    public void ChangeColorToSucceed(ButtonCardinalNumber button)
    {
        button.GetComponent<Image>().color = succeedColor;
    }

    public void ChangeColorToError(ButtonCardinalNumber button)
    {
        button.GetComponent<Image>().color = errorColor;
    }

    public void RestoreColor( )
    {
        foreach (var item in allButtons)
        {
            item.GetComponent<Image>().color = normalColor;
        }
    }

    /// <summary>
    /// Restore buttons interactability
    /// </summary>
    public void RestoreButons()
    {
        foreach (var item in allButtons)
        {
            item.GetComponent<Button>().interactable = true;
        }
    }

    /// <summary>
    /// Change if the button is interactable or not
    /// </summary>
    /// <param name="index"></param>
    /// <param name="toState"></param>
    public void ChangeButtonState(int index, bool toState)
    {
        allButtons[index].GetComponent<Button>().interactable = toState;
    }
}
