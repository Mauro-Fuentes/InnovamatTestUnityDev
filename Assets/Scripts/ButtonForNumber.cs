using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonForNumber : MonoBehaviour, IPointerClickHandler
{
    private int buttonNumber;

    public Action<int> ButtonsWasClicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        ButtonsWasClicked?.Invoke(buttonNumber);
        Debug.Log("Click on button");
    }

    public void SetButtonNumber(int newButtonNumber)
    {   
        if(buttonNumber == newButtonNumber)
        buttonNumber = newButtonNumber;
    }
}

// Maybe this should be base class... or it should be an static... or go in controller?
public class GameButtons
{
    public int min;
    public int max;

    public bool ButtonHasAnAcceptableValue(int x, int y)
    {
        return (x - min) * (max - x) >= 0;
    }
}
