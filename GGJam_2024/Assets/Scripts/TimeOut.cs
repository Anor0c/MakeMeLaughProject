using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events; 

public class TimeOut : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timeISRunning = true;
    public TMP_Text timeText;
    private MainMenu menu;
    [SerializeField] private Image uifill;
    public float timestart = 0;

    public UnityEvent OnTimerStop; 
    void Start()
    {
        timeISRunning = true;
        menu = FindAnyObjectByType<MainMenu>();
    }
    void Update()
    {
        if (timeISRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else if (timeRemaining <= 2)
            { 
                DisplayTime(timeRemaining);
            }
        }

    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay -= 1;
        if (timeRemaining <= 2)
        {
            OnTimerStop.Invoke(); 
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        uifill.fillAmount = Mathf.InverseLerp(-2, timestart,timeRemaining);
    }
}
