using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private readonly int idle = Animator.StringToHash("Idle"); 
    private readonly int hit = Animator.StringToHash("Hit"); 
    public void OnPlayerHit()
    {
        anim.CrossFade(hit, 0, 0); 

    }
}
