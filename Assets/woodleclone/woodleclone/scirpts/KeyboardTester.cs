using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyboardTester : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        KeyboardKey.onKeyPressed += Debugletter;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Debugletter(char letter) 
    {
        Debug.Log(letter);
    }
}
