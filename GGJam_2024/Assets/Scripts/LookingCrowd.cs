using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingCrowd : MonoBehaviour
{
    [SerializeField] private float damage = 1f; 
    [SerializeField] private float minCalmTimer = 0.5f, maxCalmTimer = 1.5f;
    [SerializeField] private float minLookingTimer = 0.5f, maxLookingTimer = 1.5f;
    [SerializeField] private float activeTimer, silenceWarning; 
    [SerializeField] private bool isLooking = false;
    private const float damageMultiplier = 0.01f;

    private SpriteRenderer crowdSprite;
    private JokeBehaviour player;
    private AudioSource crowdAudio; 
    [SerializeField] private UIBar shameBar;

    void Start()
    {
        crowdSprite = GetComponent<SpriteRenderer>();
        crowdAudio = GetComponent<AudioSource>(); 
        player = FindObjectOfType<JokeBehaviour>();
        damage *= damageMultiplier; 
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
            Debug.Log("SHAME!!!!"); 
            shameBar.UpdateValue(damage);
        }
    }
    private IEnumerator NoLookRoutine()
    {
        crowdSprite.color = Color.gray;
        crowdAudio.Play(); 
        activeTimer = Random.Range(minCalmTimer, maxCalmTimer);
        yield return new WaitForSeconds(activeTimer);
        crowdAudio.Pause();
        yield return new WaitForSeconds(silenceWarning); 
        isLooking = true;
        ChooseNextRoutine(); 
        yield return null;
    } 
    private IEnumerator LookingRoutine()
    {
        crowdSprite.color = Color.red;
        crowdAudio.Pause(); 
        activeTimer = Random.Range(minLookingTimer, maxLookingTimer);
        yield return new WaitForSeconds(activeTimer);
        isLooking = false;
        ChooseNextRoutine(); 
        yield return null;
    }
}
