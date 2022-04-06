using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonRomanNumber : MonoBehaviour, IPointerClickHandler
{
    private TMP_Text numberValue;
    private int buttonNumber;
    private string numberToString;

    public Action<int> ButtonsWasClicked;

    // On awake because it doesn't matter if they are inactive
    private void awake()
    {
        numberValue = GetComponentInChildren<TMP_Text>(includeInactive: true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ButtonsWasClicked?.Invoke(buttonNumber);
        Debug.Log("Click on button");
    }

    public void SetButtonNumber(string newButtonNumber)
    {
        numberToString = newButtonNumber;

        UpdateView();
    }

    private void UpdateView()
    {
        numberValue.text = buttonNumber.ToString();
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
