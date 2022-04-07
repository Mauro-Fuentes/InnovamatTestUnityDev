using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class AnimationType { }
public class SimulateAnimation : AnimationType { }
public class FromTopToBottonAnimation : AnimationType { }
public class FromHereToThere : AnimationType { }

public class AnimatorController : MonoBehaviour
{
    public AnimationCurve curve;

    SimulateAnimation simulateAnimation = new SimulateAnimation();
    FromTopToBottonAnimation fromTopToBottonAnimation = new FromTopToBottonAnimation();
    FromHereToThere fromHereToThere = new FromHereToThere();

    // for test
    public Button button;

    private void Start()
    {

    }

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

    //private IEnumerator FromBottomToTop ( Button button, float duration, FromTopToBottonAnimation typeOfAnimation)
    //{
    //    yield return null; 

    //    button.transform.position = new Vector3 (0, 0, 0); 

    //    //var initialPos = button.transform.localPosition;

    //    //float time = 0;
    //    //float rate = 1 / 6f;

    //    //while (time < duration)
    //    //{
    //    //    ///Debug.Log(time);

    //    //    time += rate * Time.deltaTime;

    //    //    button.transform.localPosition = Vector3.Lerp(initialPos, new Vector3(-300, 0, 0), curve.Evaluate(time));

    //    //    yield return null;
    //    //}

    //    //button.transform.localPosition = initialPos;
    //}

    #region Tests 

    public void CallAnimationByType()
    {
        AnimationByType(fromTopToBottonAnimation, 1);
    }

    #endregion
}


