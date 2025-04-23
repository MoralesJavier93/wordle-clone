using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardKey : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI letterText;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Test);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Test() 
    {
        Debug.Log(letterText.text);
    }
}
