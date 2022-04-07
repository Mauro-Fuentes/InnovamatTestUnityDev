using UnityEngine;

/// <summary>
/// This class ensures the Dictionary is created. Otherwise Awake or serializations don't work with Scriptables
/// </summary>
public class DictionaryReader : MonoBehaviour
{
    public DictionaryOfWords dictionaryOfWords;
}
