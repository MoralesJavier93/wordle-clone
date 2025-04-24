using TMPro;
using UnityEngine;
using TMPro;

public class letterContainer : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshPro letter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize() //made public do to calling it from a dif script
    {
        letter.text = "";
    }

    public void SetLetter(char letter) 
    {
        this.letter.text = letter.ToString();
    } 
}
