using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [Header("Select a dictionary to work with")]
    [SerializeField] private DictionaryOfWords dictionary;

    [Header("Select the main root of this controller")]
    [SerializeField] private Transform mainCanvas;

    private string bufferSpanish;   // "uno"
    private string bufferCardinal;  // "1"

    private ButtonCardinalNumber[] listOfButtonsForCardianlNumbers;
    private StartButton startButton;
    private CanvasForCardinalNumbers canvasForCardinalNumbers;
    private SpanishCanvasText canvasForSpanishNumbers; // show the first word and then desappears
    private AnimatorController animatorController;
    private CardianlButtonHelper cardinalButtonHelper;
    private TrackerCanvasController aciertosCanvasController;
    private int indexMarkedAsCorrect;

    [SerializeField] private int maxAttempts = 2; // so Devs can change it via inspector
    private int currentAttemps;

    private void Start()
    {
        CheckDictionary();
        FindCanvasForCardinalNumbers();
        FindCanvasForSpanishNumbers();
        FindAnimatorController();
        StartListeningToAnimator();
        FindButtonsForCardinalNumbers();
        StartListeningToCardinalButtons();
        FindStartButton();
        FindColorChanger();
        FindAciertosCanvasController();
        InitialiseAttempts();
    }

    #region Find Dependencies 

    private void CheckDictionary()
    {
        if (dictionary == null) Debug.LogWarning("There's no dictionary, please provide one", this);
    }

    private void FindCanvasForCardinalNumbers()
    {
        canvasForCardinalNumbers = mainCanvas.GetComponentInChildren<CanvasForCardinalNumbers>(includeInactive: true);

        ActivateCardinalCanvas(false);
    }

    private void FindCanvasForSpanishNumbers()
    {
        canvasForSpanishNumbers = mainCanvas.GetComponentInChildren<SpanishCanvasText>(includeInactive: true);

        ActivateSpanishCanvas(false);
    }

    private void FindButtonsForCardinalNumbers()
    {
        listOfButtonsForCardianlNumbers = mainCanvas.GetComponentsInChildren<ButtonCardinalNumber>(includeInactive: true);
    }    

    private void FindAnimatorController()
    {
        animatorController = FindObjectOfType<AnimatorController>();
    }

    private void FindColorChanger()
    {
        cardinalButtonHelper = FindObjectOfType<CardianlButtonHelper>();
        cardinalButtonHelper.Initialise(listOfButtonsForCardianlNumbers);
    }

    private void FindAciertosCanvasController()
    {
        aciertosCanvasController = FindObjectOfType<TrackerCanvasController>();
        if (!aciertosCanvasController) Debug.LogWarning ("Provide a canvas for Aciertos", this);
    }

    private void InitialiseAttempts()
    {
        currentAttemps = maxAttempts;
    }

    #endregion

    #region Register for events/ callbacks

    private void StartListeningToCardinalButtons()
    {
        for (int i = 0; i<listOfButtonsForCardianlNumbers.Length; i++)
        {
            listOfButtonsForCardianlNumbers[i].ButtonsWasClicked += ReactToCardinalButton;
        }
    }

    private void FindStartButton()
    {
        startButton = FindObjectOfType<StartButton>();
        if (!startButton) return;
        startButton.StartButtonWasClicked += ReactToStartButton;
    }   
    
    private void StartListeningToAnimator()
    {
        animatorController.StartAnimationFinished += OnSpanishAnimationFinished;
        animatorController.CardinalAnimationFinished += OnCardinalAnimationFinished;
        animatorController.CardinalAnimationOUTFinished += OnCardinalAnimationOUTFinished;
    }

    #endregion

    #region Reaction To Cardinal Buttons

    private void ReactToCardinalButton(ButtonCardinalNumber buttonpressed)
    {
        // React only to button pressed. Get its index
        for (int i = 0; i < listOfButtonsForCardianlNumbers.Length; i++)
        {
            if (listOfButtonsForCardianlNumbers[i] == buttonpressed)
            {
                CheckIfButtonPressedIsTheRightAnswer(i, buttonpressed);

                return;
            }
        }
    }

    private void CheckIfButtonPressedIsTheRightAnswer(int indexOfButtonPressed, ButtonCardinalNumber buttonpressed)
    {
        currentAttemps--;

        if (currentAttemps == 0) { ReStartWithCorrection(); };

        // succeed
        if (indexMarkedAsCorrect == indexOfButtonPressed)
        {
            canvasForCardinalNumbers.GetComponent<GraphicRaycaster>().enabled = false;

            // Change color of button
            cardinalButtonHelper.ChangeColorToSucceed(buttonpressed);

            // Deactivate button
            cardinalButtonHelper.ChangeButtonState(indexOfButtonPressed, toState: false);

            // Aciertos
            aciertosCanvasController.AddAciertos();

            // Animate
            animatorController.RunAnimateSucceedButton(buttonpressed);

            ReStart();
        }

        else
        {
            cardinalButtonHelper.ChangeColorToError(buttonpressed);
            cardinalButtonHelper.ChangeButtonState(indexOfButtonPressed, toState: false);
            aciertosCanvasController.AddFallo();
            animatorController.RunAnimateErrorButton(buttonpressed);
        }
    }

    #endregion

    #region Reaction To Animation

    private void OnSpanishAnimationFinished()
    {
        SetCardinalButtonsForNewData();

        animatorController.RunCardinalAnimationIN(canvasForCardinalNumbers); // fire and forget?
    }

    private void OnCardinalAnimationFinished()
    {
        ActivateCardinalCanvas(true);
    }

    private void OnCardinalAnimationOUTFinished()
    {
        ActivateCardinalCanvas(true);

        cardinalButtonHelper.RestoreColor();
        cardinalButtonHelper.RestoreButons();

        InitialiseAttempts();

        StartGame();
    }

    #endregion

    #region Starters 

    private void ReactToStartButton()
    {
        StartGame();
    }

    private void StartGame()
    {
        GetRandomSpanishNumber(); // base of the game

        animatorController.RunStartAnimation(canvasForSpanishNumbers); //Fire and forget
    }

    private void ReStart()
    {
        animatorController.RunCardinalAnimationOut(canvasForCardinalNumbers); //Fire and forget
    }

    private void ReStartWithCorrection()
    {
        // show the player the correct one
        SimulateCorrectAnswer();
    }

    private void SimulateCorrectAnswer()
    {
        var correctButton = listOfButtonsForCardianlNumbers[indexMarkedAsCorrect];

        canvasForCardinalNumbers.GetComponent<GraphicRaycaster>().enabled = false;

        // Change color of button
        cardinalButtonHelper.ChangeColorToSucceed(correctButton);

        // Animate
        animatorController.RunAnimateSucceedButton(correctButton);

        ReStart();
    }

    public void Reset()
    {
        aciertosCanvasController.ForceUpdate();
        OnCardinalAnimationOUTFinished();
    }

    #endregion

    private void ActivateCardinalCanvas(bool ToF)
    {
        canvasForCardinalNumbers.GetComponent<Canvas>().enabled = ToF;
        canvasForCardinalNumbers.GetComponent<GraphicRaycaster>().enabled = ToF;
    }

    private void ActivateSpanishCanvas(bool ToF)
    {
        canvasForSpanishNumbers.GetComponent<Canvas>().enabled = ToF;
    }

    #region Helpers

    /// <summary>
    /// Add the value GetRandomSpanish to one of the three buttons (that one is the correct answer)
    /// </summary>
    private void SetCardinalButtonsForNewData()
    {
        // Store the equivalente of bufferSpanish into bufferCardinal
        bufferCardinal = dictionary.GetCardinalEquivalentForSpanish(spanishValue: bufferSpanish);

        // select one of the three buttons THIS INT is the correct answer: say button [1]
        indexMarkedAsCorrect = Random.Range(0, listOfButtonsForCardianlNumbers.Length);

        // Use the random index above to pass the Cardinal Value
        listOfButtonsForCardianlNumbers[indexMarkedAsCorrect].PassCardinalNumberToButton(bufferCardinal);

        //parse the rest of numbers and put random values to them // they cannot be the correct answer
        for (int i = 0; i < listOfButtonsForCardianlNumbers.Length; i++)
        {
            // Don't touch the selected one
            if (i == indexMarkedAsCorrect) continue;

            // get some other random number for the rest of buttons
            string randomCardinal = dictionary.GetRandomCardinalNumber();

            if (randomCardinal == bufferSpanish) Debug.Log("Equal Numbers");

            listOfButtonsForCardianlNumbers[i].PassCardinalNumberToButton(randomCardinal);
        }
    }

    /// <summary>
    /// Call to show the Spanish number e.g. "cinco"
    /// </summary>
    private void GetRandomSpanishNumber()
    {
        string numberInSpanishWord = dictionary.GetRandomSpanishNumber();

        bufferSpanish = numberInSpanishWord;

        canvasForSpanishNumbers.GetComponentInChildren<TMPro.TMP_Text>().text = numberInSpanishWord; // this is a spanish word 
    }

    #endregion

    #region Tests

    public void StartGameDebug()
    {
        StartGame();
    }

    public void GetRandomSpanishNumberDebug()
    {
        GetRandomSpanishNumber();
    }

    public void GiveMeACardinalNumber()
    {
        dictionary.GetCardinalEquivalentForSpanish("cinco");
    }

    public void CallCardinalAnimation()
    {
        OnSpanishAnimationFinished();
    }

    #endregion

}
