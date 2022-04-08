using TMPro;
using UnityEngine;

/// <summary>
/// Concrete Aciertos y Fallos UI controller
/// </summary>
public class TrackerCanvasController : MonoBehaviour
{
    [Header("Add Text for Aciertos")]
    public TMP_Text valueForAciertos;

    [Header("Add Text for Fallos")]
    public TMP_Text valueForFallos;

    private int aciertos;
    private int fallos;

    private void Start()
    {
        FindAciertosText();

        FindFallosText();

        AssertBothAreWorking();

        ForceUpdate();
    }

    #region Find Dependencies

    private void FindFallosText()
    {
        var Fallos = GetComponentInChildren<Fallos>(includeInactive: true);
        valueForFallos = Fallos.GetComponent<TMP_Text>();
    }

    private void FindAciertosText()
    {
        var aciertosClass = GetComponentInChildren<Aciertos>(includeInactive: true);
        valueForAciertos = aciertosClass.GetComponent<TMP_Text>();
    }

    private void AssertBothAreWorking()
    {
        if (!valueForFallos || !valueForAciertos)
        {
            Debug.LogWarning("Couldn't fine where to write Fallos or Aciertos", this);
            this.gameObject.SetActive(false);
        }
    }

    public void ForceUpdate()
    {
        aciertos = 0;
        fallos = 0;
        UpdateView();
    }

    #endregion

    private void UpdateView()
    {
        valueForAciertos.text = aciertos.ToString();
        valueForFallos.text = fallos.ToString();
    }

    public void AddAciertos()
    {
        aciertos++;
        UpdateView();
    }

    public void AddFallo()
    {
        fallos++;
        UpdateView();
    }
}
