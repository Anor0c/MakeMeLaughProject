using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events; 

public class UIBar : MonoBehaviour
{
    [SerializeField]private float maxValue = 100f;
    [SerializeField]private float currentValue; 

    [SerializeField] private Image innerBar;

    public UnityEvent OnBarEmpty; 
    void Start()
    {
        currentValue = maxValue; 
    }

    public void OnUpdateValue(float delta)
    {
        currentValue -= delta; 
        innerBar.fillAmount = currentValue / maxValue;
        if (currentValue <= 0)
        {
            OnBarEmpty.Invoke(); 
        }
    }
}
