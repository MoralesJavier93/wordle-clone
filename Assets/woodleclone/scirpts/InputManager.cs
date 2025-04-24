using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private wordContainer[] wordContainers;

    [Header("Settings")]
    private int currentWordContainerIndex;

    void Start()
    {
        Initialize();

        KeyboardKey.onKeyPressed += KeyPressedCallback;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialize() 
    {
        for (int i = 0; i < wordContainers.Length; i++) 
            wordContainers[i].Initialize();
    }

    private void KeyPressedCallback(char letter) 
    {
        if (wordContainers[currentWordContainerIndex].IsComplete()) 
        {
            currentWordContainerIndex++;
        }

        wordContainers[currentWordContainerIndex].Add(letter);
    }

    private void CheckWord() 
    {
        string wordToCheck = wordContainers[currentWordContainerIndex].GetWord();
        string secretWord = WordManager.instance.GetSecretWord();

        if (wordToCheck == secretWord)
        {
            Debug.Log("Level Complete");
        }
        else 
        {
            Debug.Log("Wrong Word");
            currentWordContainerIndex++;
        }
    }
}
