using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Lookup class
/// </summary>
public class CanvasForCardinalNumbers : MonoBehaviour
{
    private Canvas canvas;
    private GraphicRaycaster raycaster;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        raycaster = GetComponent<GraphicRaycaster>();
    }

    public void ActivateCardinalCanvas(bool ToF)
    {
        canvas.enabled = ToF;
        raycaster.enabled = ToF;
    }

}
