using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Controll animations via animator on GameObjects
/// </summary>
public class AnimatorController : MonoBehaviour
{
    // It's way easier to reuse animation instead of caching them for Lenght
    public AnimationClip startAnimation;
    public AnimationClip romanAnimation;

    public Action StartAnimationFinished;
    public Action RomanAnimationFinished;

    private readonly string triggerAnimation = "TriggerAnimation";

    private void Start()
    {
        if (!startAnimation || !romanAnimation)
        {
            Debug.Log("Provide animations to cache their lenght", this);
            this.gameObject.SetActive(false);
        }
    }

    public void RunStartAnimation(SpanishCanvasText spanishCanvas)
    {
        StartCoroutine(StartAnimation(spanishCanvas));
    }

    private IEnumerator StartAnimation(SpanishCanvasText spanishText)
    {
        yield return new WaitForSeconds(.5f);

        var anim = spanishText.GetComponent<Animator>();

        anim.SetTrigger(triggerAnimation);

        yield return new WaitForSeconds(startAnimation.length);

        StartAnimationFinished?.Invoke();
    }

    public void RunRomanAnimation(CanvasForRomanNumbers romanCanvas )
    {
        StartCoroutine(RomanAnimation(romanCanvas));
    }
    private IEnumerator RomanAnimation(CanvasForRomanNumbers canvas)
    {
        var anim = canvas.GetComponent<Animator>();
        
        anim.SetTrigger(triggerAnimation);

        yield return new WaitForSeconds(romanAnimation.length);

        RomanAnimationFinished?.Invoke();
    }

    public void RunAnimationButtonSucceed()
    {

    }
}


