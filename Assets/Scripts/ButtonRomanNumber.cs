using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonRomanNumber : MonoBehaviour, IPointerClickHandler
{
    // TODO: make private
    public TMP_Text textComponent;
    
    //TODO: make private
    public string romanValue;

    public Action<ButtonRomanNumber> ButtonsWasClicked;

    private void Awake()
    {
        // TODO: parent must be active anyway. Although if not active... it will find them... but not show them until active
        textComponent = GetComponentInChildren<TMP_Text>(includeInactive: true);

        if (textComponent == null) Debug.Log("Please, ensure this button has Text", this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Button number " + index + " was clicked");

        // El index lo tiene que saber el que lo escucha... no el botón
        ButtonsWasClicked?.Invoke(this);
    }

    public void PassRomanNumberToButton(string newButtonNumber)
    {
        romanValue = newButtonNumber; // E.g "1"

        UpdateView();
    }

    public void Deactivate(bool trueOrFalse)
    {

    }

    // TODO: Error if they are inactive
    private void UpdateView()
    {
        if (!textComponent.isActiveAndEnabled) return; 

        textComponent.text = romanValue;
    }
}
