using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingCrowd : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    [SerializeField] private float minCalmTimer = 0.5f, maxCalmTimer = 1.5f;
    [SerializeField] private float minLookingTimer = 0.5f, maxLookingTimer = 1.5f;
    [SerializeField] private float activeTimer, silenceWarning;
    [SerializeField] private bool isLooking = false, isLookingRoutine = false;
    private const float damageMultiplier = 0.01f;
    private int currentIndex;

    private SpriteRenderer[] crowdSprites;
    private JokeBehaviour player;
    private AudioSource crowdAudio;
    private Animator anim;
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
        if (!isLookingRoutine)
        {
            StartCoroutine("NoLookRoutine");
            NoLookAnim(); 
        }
        if (isLookingRoutine)
        {
            StartCoroutine("LookingRoutine");
            LookAnim();
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
        isLooking = false; 
        foreach (SpriteRenderer sprite in crowdSprites)
        {
            sprite.color = Color.white;
        }
        currentIndex = Random.Range(0, crowdSprites.Length);
        crowdAudio.Play();
        activeTimer = Random.Range(minCalmTimer, maxCalmTimer);
        yield return new WaitForSeconds(activeTimer);
        isLookingRoutine = true;
        ChooseNextRoutine();
        yield return null;
    }
    private IEnumerator LookingRoutine()
    {
        crowdAudio.Pause();
        crowdSprites[currentIndex].color = Color.red;
        yield return new WaitForSeconds(silenceWarning);
        isLooking = true; 
        activeTimer = Random.Range(minLookingTimer, maxLookingTimer);
        yield return new WaitForSeconds(activeTimer);
        isLookingRoutine = false;
        ChooseNextRoutine();
        yield return null;
    }
    private void LookAnim()
    {
        anim = crowdSprites[currentIndex].gameObject.GetComponent<Animator>();
        anim.SetBool("IsLook", true);
    }
    private void NoLookAnim()
    {
        for (int i = 0; i < crowdSprites.Length; i++)
        {
            anim = crowdSprites[i].gameObject.GetComponent<Animator>();
            anim.SetBool("IsLook", false);
        }

    }
}
