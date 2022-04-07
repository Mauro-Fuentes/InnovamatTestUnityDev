using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Controll animations via animator on GameObjects
/// </summary>
public class AnimatorController : MonoBehaviour
{
    public AnimationClip anim1;

    public Action StartAnimationFinished;
    public Action RomanAnimationFinished;

    private void Start()
    {

    }

    public void RunStartAnimation(SpanishCanvasText spanishCanvas)
    {
        StartCoroutine(StartAnimation(spanishCanvas));
    }

    public void RunRomanAnimation(CanvasForRomanNumbers romanCanvas )
    {
        StartCoroutine(RomanAnimation(romanCanvas));
    }

    private IEnumerator StartAnimation(SpanishCanvasText spanishText)
    {

        yield return new WaitForSeconds(0f);

        var anim = spanishText.GetComponent<Animator>();

        anim.SetTrigger("TriggerAnimation");

        Debug.Log("Spanish Animation");

        var a = anim.GetCurrentAnimatorStateInfo(0);
        
        yield return new WaitForSeconds(a.length);

        StartAnimationFinished?.Invoke();
    }

    private IEnumerator RomanAnimation(CanvasForRomanNumbers canvas)
    {

        yield return new WaitForSeconds(0.3f);

        var anim = canvas.GetComponent<Animator>();

        anim.SetTrigger("TriggerAnimation");

        Debug.Log("Roman Animation");

        var a = anim.GetCurrentAnimatorStateInfo(0);

        yield return new WaitForSeconds(a.length);

        RomanAnimationFinished.Invoke();
    }
}


