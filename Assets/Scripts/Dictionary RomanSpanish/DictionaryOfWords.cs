using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dictionary with equivalent cardinal/spanish number
/// </summary>
/// Always a cardinal[0] "0" is spanish[0] "cero" respectively

[CreateAssetMenu(fileName = "New Dictionary", menuName = "words")]
public class DictionaryOfWords : ScriptableObject
{
    [SerializeField] private string[] keys;
    [SerializeField] private string[] values;

    private static string[] spanishNumbers =
        { 
            "cero" , "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez",
            "once" , "doce", "trece", "catorce", "quince"
        };

    [SerializeField] private static Dictionary<int, string> SpanishCardinalDictionary = new Dictionary<int, string>() { };

    // the problem with OnEnable is that if I don't open the file it's not serialized by unity
    private void OnEnable()
    {
        if (SpanishCardinalDictionary.Count > 0) { return; }

        // pair keys and values
        keys = new string[spanishNumbers.Length];
        values = new string[spanishNumbers.Length];

        PopulateDictionary();
    }

    private void PopulateDictionary()
    {
        for (int i = 0; i < spanishNumbers.Length; i++)
        {
            SpanishCardinalDictionary.Add(i, spanishNumbers[i]);

            keys[i] = SpanishCardinalDictionary[i];

            foreach (int romanNumber in SpanishCardinalDictionary.Keys)
            {
                keys[i] = romanNumber.ToString();
            }

            values[i] = SpanishCardinalDictionary[i];
        }
    }

    public string GetCardinalEquivalentForSpanish(string spanishValue)
    {
        foreach (var pair in SpanishCardinalDictionary)
        {
            if (pair.Value == spanishValue)
            {
                return pair.Key.ToString();
            }
        }

        return "0";
    }
    
    public string GetRandomSpanishNumber()
    {
        var randomInt = GetCheapRandomInt();

        return SpanishCardinalDictionary[randomInt]; // returns a value : "trece"
    }

    public string GetRandomCardinalNumber()
    {
        int randomInt = GetCheapRandomInt();

        foreach (var pair in SpanishCardinalDictionary)
        {
            if (pair.Key == randomInt)
            {
                return pair.Key.ToString();
            }
        }

        return "9999999";
    }

    /// <summary>
    /// Cheap way of returning almost real random numbers
    /// </summary>
    /// <returns></returns>
    private int GetCheapRandomInt()
    {
        int a = Random.Range(0, spanishNumbers.Length);
        int b = Random.Range(0, spanishNumbers.Length);

        return b;
    }
}