using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dictionary with equivalent roman/spanish number
/// </summary>
/// Always a roman[0] "0" is spanish[0] "cero"

[CreateAssetMenu(fileName = "New Dictionary", menuName = "words")]
public class DictionaryOfWords : ScriptableObject, ISerializationCallbackReceiver
{
    public string[] keys;
    public string[] values;

    private static string[] spanishNumbers =
        { "cero" , "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez" };

    public static Dictionary<int, string> spanishandRomanDictionary = new Dictionary<int, string>() { };

    // the problem with OnEnable is that if I don't open the file it's not serialize by unity
    private void OnEnable()
    {

        keys = new string[spanishNumbers.Length];
        values = new string[spanishNumbers.Length];

        //spanishandRomanDictionary.Clear();

        PopulateDictionary();
    }

    public void PopulateDictionary()
    {
        for (int i = 0; i < spanishNumbers.Length; i++)
        {
            spanishandRomanDictionary.Add(i, spanishNumbers[i]);

            keys[i] = spanishandRomanDictionary[i];

            foreach (int a in spanishandRomanDictionary.Keys)
            {
                keys[i] = a.ToString();
            }

            values[i] = spanishandRomanDictionary[i];
        }
    }

    public static string GetRandomSpanishNumberFromDictionary()
    {
        int a = Random.Range(0, spanishNumbers.Length);
        int b = Random.Range(0, spanishNumbers.Length);

        return spanishandRomanDictionary[b];
    }

    public static string GetRandomRomanNumberFromDictionary()
    {
        int a = Random.Range(0, spanishNumbers.Length);
        int b = Random.Range(0, spanishNumbers.Length);

        for (int i = 0; i < spanishandRomanDictionary.Count; i++)
        {
            if(i == b)
            {
                return spanishandRomanDictionary[i];
            }
        }

        return "nothing";
    }

    public void OnBeforeSerialize()
    {

    }

    public void OnAfterDeserialize()
    {

    }
}