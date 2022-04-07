using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dictionary with equivalent roman/spanish number
/// </summary>
/// Always a roman[0] "0" is spanish[0] "cero"

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

    [SerializeField] private static Dictionary<int, string> SpanishRomanDictionary = new Dictionary<int, string>() { };

    // the problem with OnEnable is that if I don't open the file it's not serialize by unity
    private void OnEnable()
    {
        if (SpanishRomanDictionary.Count > 0) { return; }

        // pair keys and values
        keys = new string[spanishNumbers.Length];
        values = new string[spanishNumbers.Length];

        PopulateDictionary();
    }

    private void PopulateDictionary()
    {
        for (int i = 0; i < spanishNumbers.Length; i++)
        {
            SpanishRomanDictionary.Add(i, spanishNumbers[i]);

            keys[i] = SpanishRomanDictionary[i];

            foreach (int romanNumber in SpanishRomanDictionary.Keys)
            {
                keys[i] = romanNumber.ToString();
            }

            values[i] = SpanishRomanDictionary[i];
        }
    }

    public string GetRomanEquivalentForSpanish(string spanishValue)
    {
        foreach (var pair in SpanishRomanDictionary)
        {
            if (pair.Value == spanishValue)
            {
                return pair.Key.ToString();
            }
        }

        return "0";
    }
    
    public string GetRandomSpanishNumberFromDictionary()
    {
        var randomInt = GetCheapRandomInt();

        return SpanishRomanDictionary[randomInt]; // returns a value : "trece"
    }

    public string GetRandomRomanNumberFromDictionary()
    {
        int randomInt = GetCheapRandomInt();

        foreach (var pair in SpanishRomanDictionary)
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