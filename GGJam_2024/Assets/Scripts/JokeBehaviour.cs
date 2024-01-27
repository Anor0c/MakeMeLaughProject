using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeBehaviour : MonoBehaviour
{
    private float fartCurrentCooldown, imitateCurrentCooldown, funnyFaceCurrentCooldown;
    private const float damageMultiplier = 0.01f; 
    [SerializeField] private float fartDamage = 1f, imitateDamage = 2f, funnyFaceDamage = 0.5f;
    [Space]
    [SerializeField] private float fartCooldown, imitateCooldown, funnyFaceCooldown;
    [Space]
    [SerializeField] private float fartActiveTime, imitateActiveTime, funnyFaceActiveTime;  
    [Space]
    [SerializeField] private bool isFartCooldown, isImitationCooldown, isFunnyFaceCooldown;
    [Space]
    [SerializeField] private bool isFarting, isImitating, isFunnyFacing; 

    [SerializeField] public PlayerStates State { get => _state; }


    [SerializeField] private UIBar laughBar; 
    private PlayerStates _state = PlayerStates.Innocent;

    private void Start()
    {
        fartDamage *= damageMultiplier;
        imitateDamage *= damageMultiplier;
        funnyFaceDamage *= damageMultiplier;
    }
    public void OnFart()
    {
        if (_state == PlayerStates.Joking)
            return;
        if (fartCurrentCooldown > 0)
            return;
        StartCoroutine(FartRoutine());

    }
    IEnumerator FartRoutine()
    {
        _state = PlayerStates.Joking;
        isFarting = true;
        yield return new WaitForSeconds(fartActiveTime);
        isFarting = false;
        fartCurrentCooldown = fartCooldown;
        yield return null;
        StopCoroutine(FartRoutine()); 
    }

    public void OnImitate()
    {
        if (_state == PlayerStates.Joking)
            return;
        if (imitateCurrentCooldown > 0)
            return;
        StartCoroutine(ImitateRoutine()); 
    }
    IEnumerator ImitateRoutine()
    {
        _state = PlayerStates.Joking;
        isImitating = true;
        yield return new WaitForSeconds(funnyFaceActiveTime);
        isImitating = false; 
        imitateCurrentCooldown = imitateCooldown;
        yield return null;
        StopCoroutine(ImitateRoutine()); 
    }
    public void OnFunnyFace()
    {
        if (_state == PlayerStates.Joking)
            return;
        if (funnyFaceCurrentCooldown > 0)
            return;
        StartCoroutine(FunnyFaceRoutine()); 

    }
    IEnumerator FunnyFaceRoutine()
    {
        _state = PlayerStates.Joking;
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
            _state = PlayerStates.Innocent;
        }
        if (fartCurrentCooldown > 0)
        {
            fartCurrentCooldown -= Time.deltaTime;
            _state = PlayerStates.InCooldown;
            isFartCooldown = true; 
        }
        else
        {
            isFartCooldown = false; 
        }
        if (imitateCurrentCooldown > 0)
        {
            imitateCurrentCooldown -= Time.deltaTime;
            _state = PlayerStates.InCooldown;
            isImitationCooldown = true; 
        }
        else
        {
            isImitationCooldown = false; 
        }
        if (funnyFaceCurrentCooldown > 0)
        {
            funnyFaceCurrentCooldown -= Time.deltaTime;
            _state = PlayerStates.InCooldown;
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
    }
}
