using UnityEngine;

public class wordContainer : MonoBehaviour
{
    [Header("Elements")]
    private letterContainer[] letterContainers;

    [Header("Settings")]
    private int currentLetterIndex;


    private void Awake()
    {
        letterContainers = GetComponentsInChildren<letterContainer>();
        //Initialize();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        for (int i = 0; i < letterContainers.Length; i++) 
        {
            letterContainers[i].Initialize();
        }
    }

    public void Add(char letter) 
    {
        letterContainers[currentLetterIndex].SetLetter(letter);
        currentLetterIndex++;
    }

    public bool RemoveLetter() 
    {
        if (currentLetterIndex <= 0) 
        {
            return false;
        }
        currentLetterIndex--;
        letterContainers[currentLetterIndex].Initialize();

        return true;
    }

    public letterContainer[] GetLetterContainers() 
    {
        return letterContainers;
    }

    public string GetWord() 
    {
        string word = "";

        for (int i = 0; i < letterContainers.Length; i++)
            word += letterContainers[i].GetLetter().ToString();

        return word;
    }
    public bool IsComplete() 
    {
        return currentLetterIndex >= 5;
    }
}
