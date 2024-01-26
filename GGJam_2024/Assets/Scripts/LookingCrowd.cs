using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingCrowd : MonoBehaviour
{
    [SerializeField] private SpriteRenderer crowdSprite;

    private Coroutine AggroRoutine, CalmRoutine; 
    [SerializeField] private float minCalmTimer = 0.5f, maxCalmTimer = 1.5f;
    [SerializeField] private float minLookingTimer = 0.5f, maxLookingTimer = 1.5f;
    [SerializeField] private float activeTimer; 
    [SerializeField] private bool isLooking = false;
    void Start()
    {
        crowdSprite = GetComponent<SpriteRenderer>(); 
        CheckLooking();
    }

    private void CheckLooking()
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
    private IEnumerator NoLookRoutine()
    {
        crowdSprite.color = Color.gray; 
        activeTimer = Random.Range(minCalmTimer, maxCalmTimer);
        yield return new WaitForSeconds(activeTimer);
        isLooking = true;
        CheckLooking(); 
        yield return null;
    } 
    private IEnumerator LookingRoutine()
    {
        crowdSprite.color = Color.red; 
        activeTimer = Random.Range(minLookingTimer, maxLookingTimer);
        yield return new WaitForSeconds(activeTimer);
        isLooking = false;
        CheckLooking(); 
        yield return null;
    }
}
