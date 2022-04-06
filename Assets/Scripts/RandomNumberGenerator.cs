using UnityEngine;

public class RandomNumberGenerator : MonoBehaviour
{
    private int minNumber;
    private int maxNumber;

    public int GenerateRandomNumber()
    {
        return Random.Range(minNumber, maxNumber);
    }
}
