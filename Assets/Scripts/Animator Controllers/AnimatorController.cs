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
    public AnimationClip cardinalAnimation;

    public Action StartAnimationFinished;
    public Action CardinalAnimationFinished;
    public Action CardinalAnimationOUTFinished;
    public Action SimulatedAnimationFinished;

    private readonly string triggerAnimation = "TriggerAnimation";
    private readonly string triggerAnimationOUT = "TriggerAnimationOUT";

    private void Start()
    {
        if (!startAnimation || !cardinalAnimation)
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
        var anim = spanishText.GetComponent<Animator>();

        anim.SetTrigger(triggerAnimation);

        yield return new WaitForSeconds(startAnimation.length);

        StartAnimationFinished?.Invoke();
    }

    public void RunCardinalAnimation(CanvasForCardinalNumbers cardinalCanvas )
    {
        StartCoroutine(CardinalAnimation(cardinalCanvas));
    }
    private IEnumerator CardinalAnimation(CanvasForCardinalNumbers canvas)
    {
        var anim = canvas.GetComponent<Animator>();
        
        anim.SetTrigger(triggerAnimation);

        yield return new WaitForSeconds(cardinalAnimation.length);

        CardinalAnimationFinished?.Invoke();
    }

    public void RunSimulateTime()
    {
        StartCoroutine(SimulateTime());
    }
    private IEnumerator SimulateTime()
    {
        yield return new WaitForSeconds(5);
        SimulatedAnimationFinished?.Invoke();
    }

    public void RunCardinalAnimationOut(CanvasForCardinalNumbers cardinalCanvas)
    {
        StartCoroutine(CardinalAnimationOUT(cardinalCanvas));
    }
    private IEnumerator CardinalAnimationOUT(CanvasForCardinalNumbers canvas)
    {
        var anim = canvas.GetComponent<Animator>();

        anim.SetTrigger(triggerAnimationOUT);

        yield return new WaitForSeconds(cardinalAnimation.length);

        CardinalAnimationOUTFinished?.Invoke();
    }

    /// <summary>
    /// Animate button. They should have their own animation inside
    /// </summary>
    public void RunAnimateSucceedButton(ButtonCardinalNumber button)
    {
        StartCoroutine(AnimateSuccedButton(button));
    }

    private IEnumerator AnimateSuccedButton(ButtonCardinalNumber button)
    {
        var anim = button.GetComponent<Animator>();
        anim.SetTrigger("TriggerSucceed");   
        yield return new WaitForSeconds(1f);
    }

    public void RunAnimateErrorButton(ButtonCardinalNumber button)
    {
        StartCoroutine(AnimateErrorButton(button));
    }

    public IEnumerator AnimateErrorButton(ButtonCardinalNumber button)
    {
        var anim = button.GetComponent<Animator>();
        anim.SetTrigger("TriggerError");
        yield return new WaitForSeconds(1f);
    }
}

