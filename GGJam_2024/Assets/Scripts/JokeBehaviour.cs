using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeBehaviour : MonoBehaviour
{
    private float fartCurrentCooldown, imitateCurrentCooldown, funnyFaceCurrentCooldown;
    [Space]
    [SerializeField] private float fartCooldown, imitateCooldown, funnyFaceCooldown;
    [Space]
    [SerializeField] private float fartActiveTime, imitateActiveTime, funnyFaceActiveTime;  
    [Space]
    [SerializeField] private bool isFartCooldown, isImitationCooldown, isFunnyFaceCooldown;

    [Space]
    [SerializeField] private bool isFarting, isImitating, isFunnyFacing; 

    [SerializeField] private PlayerStates state = PlayerStates.Innocent;

    public void OnFart()
    {
        if (state == PlayerStates.Joking)
            return;
        if (fartCurrentCooldown > 0)
            return;
        StartCoroutine(FartRoutine());

    }
    IEnumerator FartRoutine()
    {
        state = PlayerStates.Joking;
        isFarting = true;
        yield return new WaitForSeconds(fartActiveTime);
        isFarting = false;
        fartCurrentCooldown = fartCooldown;
        yield return null;
        StopCoroutine(FartRoutine()); 
    }

    public void OnImitate()
    {
        if (state == PlayerStates.Joking)
            return;
        if (imitateCurrentCooldown > 0)
            return;
        StartCoroutine(ImitateRoutine()); 
    }
    IEnumerator ImitateRoutine()
    {
        state = PlayerStates.Joking;
        isImitating = true;
        yield return new WaitForSeconds(funnyFaceActiveTime);
        isImitating = false; 
        imitateCurrentCooldown = imitateCooldown;
        yield return null;
        StopCoroutine(ImitateRoutine()); 
    }
    public void OnFunnyFace()
    {
        if (state == PlayerStates.Joking)
            return;
        if (funnyFaceCurrentCooldown > 0)
            return;
        StartCoroutine(FunnyFaceRoutine()); 

    }
    IEnumerator FunnyFaceRoutine()
    {
        state = PlayerStates.Joking;
        isFunnyFacing = true;
        yield return new WaitForSeconds(funnyFaceActiveTime);
        isFunnyFacing = false; 
        funnyFaceCurrentCooldown = funnyFaceCooldown; 
        yield return null;
        StopCoroutine(FunnyFaceRoutine()); 
    }
    public void OnWhistle()
    {

    }
    private void Update()
    {
        if (fartCurrentCooldown <= 0 && imitateCurrentCooldown <= 0 && funnyFaceCurrentCooldown <= 0 && !isFarting && !isImitating && !isFunnyFacing)
        {
            state = PlayerStates.Innocent;
        }
        if (fartCurrentCooldown > 0)
        {
            fartCurrentCooldown -= Time.deltaTime;
            state = PlayerStates.InCooldown;
            isFartCooldown = true; 
        }
        else
        {
            isFartCooldown = false; 
        }
        if (imitateCurrentCooldown > 0)
        {
            imitateCurrentCooldown -= Time.deltaTime;
            state = PlayerStates.InCooldown;
            isImitationCooldown = true; 
        }
        else
        {
            isImitationCooldown = false; 
        }
        if (funnyFaceCurrentCooldown > 0)
        {
            funnyFaceCurrentCooldown -= Time.deltaTime;
            state = PlayerStates.InCooldown;
            isFunnyFaceCooldown = true; 
        }
        else
        {
            isFunnyFaceCooldown = false; 
        }
    }
}
