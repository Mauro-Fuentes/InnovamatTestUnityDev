using UnityEngine;

public class Controller : MonoBehaviour
{
    // for now I will have this class... maybe it's not necessary 
    public RandomNumberGenerator RandomNumberGenerator;

    [SerializeField] public ButtonForNumber[] listOfButtonsForNumbers;

    public StartButton startButton;

    private void Start()
    {
        RandomNumberGenerator = FindObjectOfType<RandomNumberGenerator>();

        FindButtonFornumbersOnSystem();

        FindStartButton();
    }

    private void FindButtonFornumbersOnSystem()
    {
        listOfButtonsForNumbers = FindObjectsOfType<ButtonForNumber>();
        for (int i = 0; i < listOfButtonsForNumbers.Length; i++)
        {
            listOfButtonsForNumbers[i].ButtonsWasClicked += ReactToButtonNumberClicked;
        }
    }

    private void FindStartButton()
    {
        startButton = FindObjectOfType<StartButton>();
        startButton.StartButtonWasClicked += ReactToStartButton;
    }





    private void ReactToStartButton()
    {

    }

    private void ReactToButtonNumberClicked(int numberOfButton)
    {

    }
}
