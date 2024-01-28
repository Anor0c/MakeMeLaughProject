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

    private SpriteRenderer[] crowdSprites;
    private JokeBehaviour player;
    private AudioSource crowdAudio;
    [SerializeField] private UIBar shameBar;

    void Start()
    {
        crowdSprites = GetComponentsInChildren<SpriteRenderer>();
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

        if (isLooking && player.IsJoking)
        {
            shameBar.UpdateValue(damage);
        }
    }
    private IEnumerator NoLookRoutine()
    {
        /*foreach (SpriteRenderer sprite in crowdSprites)
        {
            sprite.color = Color.gray;
        }*/
        
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
        crowdSprites[Random.Range(0, crowdSprites.Length)].color = Color.red;
        crowdAudio.Pause();
        activeTimer = Random.Range(minLookingTimer, maxLookingTimer);
        yield return new WaitForSeconds(activeTimer);
        isLooking = false;
        ChooseNextRoutine();
        yield return null;
    }
}
