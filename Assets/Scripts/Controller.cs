using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Select a dictionary")]
    public DictionaryOfWords dictionary;

    [Header("Select the main root of this controller")]
    public Transform mainCanvas;   
    
    [SerializeField] public ButtonRomanNumber[] listOfButtonsForRomanNumbers;

    public StartButton startButton;

    public CanvasForRomanNumbers canvasForRomanNumbers;

    public SpanishText spanishText; // show the first word and then desappears

    public string bufferSpanish; // uno
    public string bufferRoman;     // 1

    private int indexMarkedAsCorrect;

    public AnimatorController animatorController;

    private void Start()
    {
        CheckDictionary();
        FindCanvasForRomanNumbers();
        FindCanvasForSpanishNumbers();
        FindAnimatorController();
        FindButtonsForRomanNumbers();
        StartListeningToRomanButtons();
        FindStartButton();
    }

    #region Find Dependencies 

    private void CheckDictionary()
    {
        if (dictionary == null) Debug.LogWarning("There's no dictionary, please provide one");
    }

    private void FindCanvasForRomanNumbers()
    {
        canvasForRomanNumbers = mainCanvas.GetComponentInChildren<CanvasForRomanNumbers>(includeInactive: true);
        ActivateRomanCanvas(false);
    }

    private void FindCanvasForSpanishNumbers()
    {
        spanishText = mainCanvas.GetComponentInChildren<SpanishText>(includeInactive: true);
        spanishText.gameObject.SetActive(false);
    }

    private void FindButtonsForRomanNumbers()
    {
        listOfButtonsForRomanNumbers = mainCanvas.GetComponentsInChildren<ButtonRomanNumber>(includeInactive: true);
    }
    
    private void StartListeningToRomanButtons()
    {
        for (int i = 0; i<listOfButtonsForRomanNumbers.Length; i++)
        {
            listOfButtonsForRomanNumbers[i].ButtonsWasClicked += ReactToRomanButton;
        }
    }

    private void FindStartButton()
    {
        startButton = FindObjectOfType<StartButton>();
        if (!startButton) return;
        startButton.StartButtonWasClicked += ReactToStartButton;
    }

    private void FindAnimatorController()
    {
        animatorController = FindObjectOfType<AnimatorController>();
    }

    #endregion

    #region Reaction To Button Actions

    private void ReactToStartButton()
    {
        Debug.Log("Start game");
        startButton.gameObject.SetActive(false);
        StartGame();
    }

    private void ReactToRomanButton(ButtonRomanNumber buttonpressed)
    {
        // this gets the index of button
        for (int i = 0; i < listOfButtonsForRomanNumbers.Length; i++)
        {
            if (listOfButtonsForRomanNumbers[i] == buttonpressed)
            {
                Debug.Log("Button " + i + " was pressed");
                CheckIfTheButtonPressedIsTheRightAnswer(i);
                return;
            }
        }
    }

    private void CheckIfTheButtonPressedIsTheRightAnswer(int indexOfButtonPressed)
    {
        if (indexMarkedAsCorrect == indexOfButtonPressed)
        {
            Debug.Log("Checkpoint!!! " + indexOfButtonPressed + bufferSpanish);
        }
    }

    #endregion

    /// <summary>
    /// Call to show the Spanish number e.g. "cinco"
    /// </summary>
    private void GetRandomSpanishNumber()
    {
        string numberInSpanishWord = dictionary.GetRandomSpanishNumberFromDictionary();

        bufferSpanish = numberInSpanishWord;

        spanishText.GetComponent<TMPro.TMP_Text>().text = numberInSpanishWord; // this is a spanish word 
    }

    // TODO: no llega a activar si el parent está desactivado.
    private void StartGame()
    {
        GetRandomSpanishNumber(); // base of the game

        PrepareRomanButtonsToDisplayNewSetOfNumbers();

        ActivateRomanCanvas(true);
    }

    private void ActivateRomanCanvas(bool ToF)
    {
        canvasForRomanNumbers.GetComponent<Canvas>().enabled = ToF;
    }

    /// <summary>
    /// From the three buttons... choose 1 and pass the same GetRandomSpanish (that one is the correct answer)
    /// </summary>
    private void PrepareRomanButtonsToDisplayNewSetOfNumbers()
    {
        // The correct number is the spanish buffer; "Cinco"
        bufferRoman = dictionary.GetRomanEquivalentForSpanish(spanishValue: bufferSpanish);

        // select one of the three buttons THIS INT is the correct answer: say button [1]
        indexMarkedAsCorrect = Random.Range(0, listOfButtonsForRomanNumbers.Length);

        // pass the spanish "cinco". Use the random index above. Say use button [1] pass the "ROMAN REFERENCE"
        listOfButtonsForRomanNumbers[indexMarkedAsCorrect].PassRomanNumberToButton(bufferRoman);

        //parse the rest of number and put random values to them
        for (int i = 0; i < listOfButtonsForRomanNumbers.Length; i++)
        {
            // Don't touch the selected one
            if (i == indexMarkedAsCorrect) continue;

            // get some other random number for the rest of buttons
            string randomRoman = dictionary.GetRandomRomanNumberFromDictionary();

            listOfButtonsForRomanNumbers[i].PassRomanNumberToButton(randomRoman);
        }
    }

    #region Tests

    public void StartGameDebug()
    {
        StartGame();
    }

    public void GetRandomSpanishNumberDebug()
    {
        GetRandomSpanishNumber();
    }

    public void GiveMeaRomanNumber()
    {
        dictionary.GetRomanEquivalentForSpanish("cinco");
    }

    #endregion

}
