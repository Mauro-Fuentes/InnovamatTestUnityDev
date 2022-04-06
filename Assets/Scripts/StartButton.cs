using System;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// Button Start > Starts the game. This is 
/// </summary>
/// <remarks>
/// This is just a courtesy button
/// </remarks>
public class StartButton : MonoBehaviour, IPointerClickHandler
{
    public Action StartButtonWasClicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        StartButtonWasClicked?.Invoke();
    }
}
