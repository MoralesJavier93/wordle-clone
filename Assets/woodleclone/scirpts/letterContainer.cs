using TMPro;
using UnityEngine;

public class letterContainer : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshPro letter;
    [SerializeField] private SpriteRenderer backgroundRenderer;

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

    public char GetLetter() 
    {
        return letter.text[0];
    }
    public void SetColor(Color color)
    {
        backgroundRenderer.color = color;
    }
}
