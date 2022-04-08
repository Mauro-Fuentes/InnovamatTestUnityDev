using UnityEngine;
using TMPro;

public class SpanishCanvasText : MonoBehaviour
{
    private Canvas canvas;
    private TMP_Text TMP;

    private void Awake()
    {
        FindComponents();
    }

    private void FindComponents()
    {
        canvas = GetComponentInChildren<Canvas>(includeInactive: true);
        if (!canvas) Debug.Log("There's no canvas. Please provide one", this);

        TMP = GetComponentInChildren<TMP_Text>();
        if (!TMP) Debug.Log("I need a TMP component. Please provide one", this);
    }

    public void ActivateSpanishCanvas(bool state)
    {
        canvas.enabled = state;
    }

    public void UpdateView(string numberInSpanishWord)
    {
        TMP.text = numberInSpanishWord;
    }
}
