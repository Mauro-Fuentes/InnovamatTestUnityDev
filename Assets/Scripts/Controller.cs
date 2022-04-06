using UnityEngine;

public class Controller : MonoBehaviour
{
    // for now I will have this class... maybe it's not necessary 
    public RandomNumberGenerator RandomNumberGenerator;

    [SerializeField] public ButtonRomanNumber[] listOfButtonsForNumbers;

    public StartButton startButton;

    public CanvasForRomanNumbers canvasForNumbers;

    public Transform mainCanvas;

    public SpanishText spanishText;

    public string bufferSpanish;
    public string bufferRoman;

    private void Start()
    {
        FindRandomGenerator();
        FindCanvasForRomanNumbers();
        FindCanvasForSpanishNumbers();

        FindButtonsForRomanNumbers();

        //FindStartButton();

        GetRandomSpanishNumber(); // this is just a test

        // now I need to pass that random to one of the buttons
        GetRandoRomanNumber(); // this is for buttons

        ManagerButtonsGame();
    }

    private void FindRandomGenerator()
    {
        RandomNumberGenerator = FindObjectOfType<RandomNumberGenerator>();
    }

    private void FindCanvasForRomanNumbers()
    {
        //canvasForNumbers = mainCanvas.GetComponentInChildren<CanvasForNumbers>(includeInactive: true);
        //canvasForNumbers.gameObject.SetActive(false);
    }

    private void FindCanvasForSpanishNumbers()
    {
        spanishText = mainCanvas.GetComponentInChildren<SpanishText>(includeInactive: true);
    }

    private void FindButtonsForRomanNumbers()
    {
        listOfButtonsForNumbers = FindObjectsOfType<ButtonRomanNumber>();

        for (int i = 0; i < listOfButtonsForNumbers.Length; i++)
        {
            listOfButtonsForNumbers[i].ButtonsWasClicked += ReactToButtonNumberClicked;
        }
    }

    private void FindStartButton()
    {
        startButton = mainCanvas.GetComponentInChildren<StartButton>(includeInactive: true);
        startButton.StartButtonWasClicked += ReactToStartButton;
    }


    private void ReactToStartButton()
    {
        Debug.Log("Start game");
        startButton.gameObject.SetActive(false);
        StartGame();
    }

    private void ReactToButtonNumberClicked(int numberOfButton)
    {
        CheckIfTheOptionIsRight();
    }

    private void CheckIfTheOptionIsRight()
    {

    }

    // we must keep track of the [index] cause it's the same for the whole system
    private void GetRandomSpanishNumber()
    {
        string numberInSpanishWord = DictionaryOfWords.GetRandomSpanishNumberFromDictionary();

        bufferSpanish = numberInSpanishWord;

        spanishText.GetComponent<TMPro.TMP_Text>().text = numberInSpanishWord; // this is a spanish word 
    }

    private void GetRandoRomanNumber()
    {
        string numberInRoman = DictionaryOfWords.GetRandomRomanNumberFromDictionary();

        bufferRoman = numberInRoman;

        //spanishText.GetComponent<TMPro.TMP_Text>().text = numberInRoman; // this is a roman word

    }

    /// <summary>
    /// From the three buttons... choose 1 and pass the same GetRandomSpanish (that one is the correct answer)
    /// </summary>
    private void ManagerButtonsGame()
    {
        // select one of the three buttons... 
        var a = Random.Range(0, listOfButtonsForNumbers.Length);

        // pass that int value to select a button and change text value
        listOfButtonsForNumbers[a].SetButtonNumber(bufferSpanish);

        for (int i = 0; i < listOfButtonsForNumbers.Length; i++)
        {
            if (i == a) continue;

            listOfButtonsForNumbers[i].SetButtonNumber(bufferSpanish);
        }
    }

    private void StartGame()
    {
        ShowUINumbers();
    }

    private void ShowUINumbers()
    {
        canvasForNumbers.gameObject.SetActive(true);

        for (int i = 0; i < listOfButtonsForNumbers.Length; i++)
        {
            //listOfButtonsForNumbers[i].SetButtonNumber(Words.spanishNumbers[i]);
        }
    }


}
