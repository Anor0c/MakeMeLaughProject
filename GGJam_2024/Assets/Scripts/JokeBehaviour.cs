using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeBehaviour : MonoBehaviour
{
    [SerializeField] private float fartCurrentCooldown, imitateCurrentCooldown, funnyFaceCurrentCooldown;
    [SerializeField] private float fartCooldown, imitateCooldown, funnyFaceCooldown;

    void Start()
    {
        
    }

    public void OnFart()
    {
        if (fartCurrentCooldown >= 0)
            return;
        //logique 
        fartCurrentCooldown = fartCooldown; 
    }
    public void OnImitate()
    {
        if (imitateCurrentCooldown >= 0)
            return;

        imitateCurrentCooldown = imitateCooldown; 
    }
    public void OnFunnyFace()
    {
        if (funnyFaceCurrentCooldown >= 0)
            return;

        funnyFaceCurrentCooldown = funnyFaceCooldown; 
    }
    public void OnWhistle()
    {

    }
    private void Update()
    {
        if (fartCurrentCooldown > 0)
        {
            fartCurrentCooldown -= Time.deltaTime; 
        }
        if (imitateCurrentCooldown > 0)
        {
            imitateCurrentCooldown -= Time.deltaTime;
        }
        if (funnyFaceCurrentCooldown > 0)
        {
            funnyFaceCurrentCooldown -= Time.deltaTime; 
        }
    }
}
