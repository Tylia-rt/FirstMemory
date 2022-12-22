using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonCard : MonoBehaviour
{
    public UnityEvent WhenClicked;
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        WhenClicked.Invoke();
    }
}
