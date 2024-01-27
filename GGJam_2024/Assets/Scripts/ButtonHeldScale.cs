using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHeldScale : MonoBehaviour
{
    private RectTransform button;
    private JokeBehaviour player; 
    private bool buttonHeld;
    private bool hasBeenHeld;
    private float normalScale = 100f; 
    private float maxScale = 120f; 

    void Start()
    {
        button = GetComponent<RectTransform>();
        player = FindObjectOfType<JokeBehaviour>(); 
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
        if (buttonHeld&&!player.IsFartCooldown)
        {
            button.sizeDelta += new Vector2(Time.deltaTime*10, Time.deltaTime*10); 
        }
        if (button.sizeDelta.y >= maxScale)
        {
            buttonHeld = false; 
        }
    }
}
