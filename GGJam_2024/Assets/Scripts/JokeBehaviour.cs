using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeBehaviour : MonoBehaviour
{
    private float fartCurrentCooldown, imitateCurrentCooldown, funnyFaceCurrentCooldown;
    private const float damageMultiplier = 0.01f;
    [SerializeField] private float fartDamage = 1f, imitateDamage = 2f, funnyFaceDamage = 0.5f;
    private float maxFartDamage = 2f; 
    [Space]
    [SerializeField] private float fartCooldown, imitateCooldown, funnyFaceCooldown;

    [SerializeField] private float fartActiveTime, imitateActiveTime, funnyFaceActiveTime;
    [Space]
    [SerializeField] private float whistleReductionRate, maxReductionRate, minReductionRate;
    [Space]
    [SerializeField] private bool isFartCooldown, isImitationCooldown, isFunnyFaceCooldown;
    [Space]
    [SerializeField] private bool isFarting, isImitating, isFunnyFacing, isJoking;
    private bool fartHeld; 
    public bool IsFartCooldown { get => isFartCooldown; }
    public bool IsImitationCooldown { get => isImitationCooldown; }
    public bool IsFunnyFaceCooldown { get => isFunnyFaceCooldown; }

    public bool IsFarting { get => isFarting; }
    public bool IsImitating { get => isImitating; }
    public bool IsFunnyFacing { get => isFunnyFacing; }
    public bool IsJoking { get => isJoking; }


    [SerializeField] private UIBar laughBar;


    private void Start()
    {
        fartDamage *= damageMultiplier;
        imitateDamage *= damageMultiplier;
        funnyFaceDamage *= damageMultiplier;
        maxFartDamage *= damageMultiplier; 
        whistleReductionRate = minReductionRate; 
    }
    public void OnFart()
    {

        if (fartCurrentCooldown > 0)
            return;
        StartCoroutine(FartRoutine());

    }
    IEnumerator FartRoutine()
    {
        isFarting = true;
        yield return new WaitForSeconds(fartActiveTime);
        isFarting = false;
        fartCurrentCooldown = fartCooldown;
        yield return null;
        StopCoroutine(FartRoutine()); 
    }
    public void FartHold()
    {
        fartHeld = true; 
    }
    public void FartRelease()
    {
        fartHeld = false; 
    }

    public void OnImitate()
    {
        if (imitateCurrentCooldown > 0)
            return;
        StartCoroutine(ImitateRoutine()); 
    }
    IEnumerator ImitateRoutine()
    {
        isImitating = true;
        yield return new WaitForSeconds(funnyFaceActiveTime);
        isImitating = false; 
        imitateCurrentCooldown = imitateCooldown;
        yield return null;
        StopCoroutine(ImitateRoutine()); 
    }
    public void OnFunnyFace()
    {
        if (funnyFaceCurrentCooldown > 0)
            return;
        StartCoroutine(FunnyFaceRoutine()); 

    }
    IEnumerator FunnyFaceRoutine()
    {
        isFunnyFacing = true;
        yield return new WaitForSeconds(funnyFaceActiveTime);
        isFunnyFacing = false; 
        funnyFaceCurrentCooldown = funnyFaceCooldown; 
        yield return null;
        StopCoroutine(FunnyFaceRoutine()); 
    }
    public void OnWhistle()
    {
        whistleReductionRate = maxReductionRate;
    }
    public void OnStopWhistle()
    {
        whistleReductionRate = minReductionRate; 
    }
    private void Update()
    {
        if (!isFarting && !isImitating && !isFunnyFacing)
        {
            isJoking = false;  
        }
        else
        {
            isJoking = true; 
        }
        if (fartCurrentCooldown > 0)
        {
            fartCurrentCooldown -= Time.deltaTime*whistleReductionRate;
            isFartCooldown = true; 
        }
        else
        {
            isFartCooldown = false; 
        }
        if (imitateCurrentCooldown > 0)
        {
            imitateCurrentCooldown -= Time.deltaTime*whistleReductionRate;
            isImitationCooldown = true; 
        }
        else
        {
            isImitationCooldown = false; 
        }
        if (funnyFaceCurrentCooldown > 0)
        {
            funnyFaceCurrentCooldown -= Time.deltaTime*whistleReductionRate;
            isFunnyFaceCooldown = true; 
        }
        else
        {
            isFunnyFaceCooldown = false; 
        }
        if (isFarting)
        {
            laughBar.UpdateValue(fartDamage);
        }
        if(isImitating)
        {
            laughBar.UpdateValue(imitateDamage); 
        }
        if(isFunnyFacing)
        {
            laughBar.UpdateValue(funnyFaceDamage); 
        }
        if (fartHeld)
        {
            fartDamage += Time.deltaTime/100; 
        }
        if (fartDamage >= maxFartDamage)
        {
            FartRelease(); 
        }
    }
}
