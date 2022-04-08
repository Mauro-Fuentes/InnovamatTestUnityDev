using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class AnimationType { }
public class SimulateAnimation : AnimationType { }
public class FromTopToBottonAnimation : AnimationType { }
public class FromHereToThere : AnimationType { }

/// <summary>
/// Variant of AnimatorController but for animation through code
/// </summary>
public class AnimatorControllerByCode : MonoBehaviour
{
    SimulateAnimation simulateAnimation = new SimulateAnimation();
    FromTopToBottonAnimation fromTopToBottonAnimation = new FromTopToBottonAnimation();
    FromHereToThere fromHereToThere = new FromHereToThere();

    private void AnimationByType(FromTopToBottonAnimation animationType, int time)
    {
        StartCoroutine(ChooseAnimation(animationType));
    }
    private void AnimationByType(FromHereToThere animationType, int time)
    {
        StartCoroutine(ChooseAnimation(animationType));
    }
    private void AnimationByType(SimulateAnimation simulateAnimation, int time)
    {
        StartCoroutine(ChooseAnimation(simulateAnimation, time));
    }

    private IEnumerator ChooseAnimation() { yield return null; }
    private IEnumerator ChooseAnimation(FromTopToBottonAnimation animation)
    {
        button.transform.position = new Vector3(0, 0, 0);

        Debug.Log("Animation Started");

        yield return null;
    }
    private IEnumerator ChooseAnimation(FromHereToThere snimation) { yield return null; }
    private IEnumerator ChooseAnimation(SimulateAnimation animation, int time)
    {
        yield return new WaitForSeconds(time); // we can buffer this
        Debug.Log("Animation ended");
    }

    #region Tests 

    // for testing
    public Button button;

    public AnimationCurve curve;

    public void CallAnimationByType()
    {
        AnimationByType(fromTopToBottonAnimation, 1);
    }

    #endregion
}