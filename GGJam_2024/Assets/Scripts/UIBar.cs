using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIBar : MonoBehaviour
{
    [SerializeField]private float maxValue = 100f;
    [SerializeField]private float currentValue; 

    [SerializeField] private Image innerBar; 

    // Start is called before the first frame update
    void Start()
    {
        currentValue = maxValue; 
    }

    public void OnUpdateValue(float delta)
    {
        currentValue -= delta; 
        innerBar.fillAmount = currentValue / maxValue; 
    }
}
