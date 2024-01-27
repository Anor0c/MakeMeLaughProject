using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHeldScale : MonoBehaviour
{
    private RectTransform button;
    private bool buttonHeld;
    private float normalScale = 100f; 
    private float maxScale = 120f; 

    void Start()
    {
        button = GetComponent<RectTransform>();
    }

    public void Held()
    {
        buttonHeld=true; 
    }
    public void Released()
    {
        buttonHeld = false;
        button.sizeDelta = new Vector2(normalScale, normalScale); 
    }
    void Update()
    {
        if (buttonHeld)
        {
            button.sizeDelta += new Vector2(Time.deltaTime*10, Time.deltaTime*10); 
        }
        if (button.sizeDelta.y >= maxScale)
        {
            buttonHeld = false; 
        }
    }
}
