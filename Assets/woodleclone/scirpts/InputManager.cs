using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;


public class InputManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private wordContainer[] wordContainers;
    [SerializeField] private Button tryButton;

    [Header("Settings")]
    private int currentWordContainerIndex;
    private bool canAddLetter = true;

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
        if (!canAddLetter) 
        {
            return;
        }
        wordContainers[currentWordContainerIndex].Add(letter);

        if (wordContainers[currentWordContainerIndex].IsComplete())
        {
            canAddLetter = false;
            EnableTryButton();
            //CheckWord();
            //currentWordContainerIndex++;
        }
    }

    public void CheckWord() 
    {
        string wordToCheck = wordContainers[currentWordContainerIndex].GetWord();
        string secretWord = WordManager.instance.GetSecretWord();

        char[] answerArray = secretWord.ToCharArray();
        char[] guessArray = wordToCheck.ToCharArray();
        Color[] boxColor = new Color[5];
        bool[] letterUsed = new bool[5]; // shows what letters are used 

        for (int i = 0; i < 5; i++) //singals that the enter was corrceted aka turn it green
        {
            if (guessArray[i] == answerArray[i]) 
            {
                boxColor[i] = Color.green;
                letterUsed[i] = true;
            }
        }

        for (int i = 0; i < 5; i++) // this will trun it yellow or gray
        {
            if (boxColor[i] == Color.green) continue;

            bool found = false;
            for (int j = 0; j < 5; j++) 
            {
                if (!letterUsed[j] && guessArray[i] == answerArray[j]) 
                {
                    found = true;
                    letterUsed[j] = true;
                    break;
                }
                
            }
            boxColor[i] =  found ? Color.yellow : Color.gray;
        }

        var letterBoxes = wordContainers[currentWordContainerIndex].GetLetterContainers();
        for (int i = 0; i < 5; i++) 
        {
            letterBoxes[i].SetColor(boxColor[i]);
        }

        if (wordToCheck == secretWord)
        {
            Debug.Log("Level Complete");
        }
        else 
        {
            Debug.Log("Wrong Word");
            canAddLetter = true ;
            DisableTryButton(); 
            currentWordContainerIndex++;
        }
    }


    public void BackspacePressedCallback() 
    {
        bool removedLetter = wordContainers[currentWordContainerIndex].RemoveLetter();
        if (removedLetter) 
        {
            DisableTryButton() ;
        }
        canAddLetter = true;
    }

    private void EnableTryButton() 
    {
        tryButton.interactable = true;
    }

    private void DisableTryButton() 
    {
        tryButton.interactable = false;
    }
}
