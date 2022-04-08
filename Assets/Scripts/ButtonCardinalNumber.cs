using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// Button for Cardinal Values
/// </summary>
public class ButtonCardinalNumber : MonoBehaviour, IPointerClickHandler
{
    private TMP_Text textComponent;
    private string cardinalValue;
    private Button thisButton;

    public Action<ButtonCardinalNumber> ButtonsWasClicked;

    private void Awake()
    {
        textComponent = GetComponentInChildren<TMP_Text>(includeInactive: true);
        thisButton = GetComponent<Button>();

        if (textComponent == null) Debug.Log("Please, ensure this button has Text", this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Even without raycaster this works so I need to hijack it
        if(!thisButton.interactable) { return; }

        ButtonsWasClicked?.Invoke(this);
    }

    public void PassCardinalNumberToButton(string newButtonNumber)
    {
        cardinalValue = newButtonNumber; // E.g "1"

        UpdateView();
    }

    public void Deactivate(bool trueOrFalse)
    {

    }
 
    private void UpdateView()
    {
        if (!textComponent.isActiveAndEnabled) return; 

        textComponent.text = cardinalValue;
    }

}
