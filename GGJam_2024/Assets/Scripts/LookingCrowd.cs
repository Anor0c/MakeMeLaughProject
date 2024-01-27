using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingCrowd : MonoBehaviour
{
    private SpriteRenderer crowdSprite;
    private JokeBehaviour player;
    [SerializeField] private UIBar laughBar; 

    private Coroutine AggroRoutine, CalmRoutine;
    [SerializeField] private float damage = 1f; 
    [SerializeField] private float minCalmTimer = 0.5f, maxCalmTimer = 1.5f;
    [SerializeField] private float minLookingTimer = 0.5f, maxLookingTimer = 1.5f;
    [SerializeField] private float activeTimer; 
    [SerializeField] private bool isLooking = false;
    void Start()
    {
        crowdSprite = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<JokeBehaviour>(); 
        ChooseNextRoutine();
    }

    private void ChooseNextRoutine()
    {
        StopAllCoroutines(); 
        if (!isLooking)
        {
            StartCoroutine("NoLookRoutine"); 
        }
        if (isLooking)
        {
            StartCoroutine("LookingRoutine");
        }
    }
    private void Update()
    {
        if (player.State == PlayerStates.Joking && isLooking)
        {
            laughBar.UpdateValue(damage);
        }
    }
    private IEnumerator NoLookRoutine()
    {
        crowdSprite.color = Color.gray; 
        activeTimer = Random.Range(minCalmTimer, maxCalmTimer);
        yield return new WaitForSeconds(activeTimer);
        isLooking = true;
        ChooseNextRoutine(); 
        yield return null;
    } 
    private IEnumerator LookingRoutine()
    {
        crowdSprite.color = Color.red; 
        activeTimer = Random.Range(minLookingTimer, maxLookingTimer);
        yield return new WaitForSeconds(activeTimer);
        isLooking = false;
        ChooseNextRoutine(); 
        yield return null;
    }
}
