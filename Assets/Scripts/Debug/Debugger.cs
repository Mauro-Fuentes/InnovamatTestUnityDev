using UnityEngine;

public class Debugger : MonoBehaviour
{
    private Canvas canvas;

    private void Start()
    {
        canvas = GetComponentInChildren<Canvas>(includeInactive: true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (canvas.enabled) EnableDebugger(false);
            else EnableDebugger(true);
        }
    }

    private void EnableDebugger(bool state)
    {
        canvas.enabled = state;
    }


}
