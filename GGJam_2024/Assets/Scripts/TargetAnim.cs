using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAnim : MonoBehaviour
{
    private Animator anim; 
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnLaugh()
    {
        anim.SetBool("IsLaugh", true); 
    }
    public void OnIdle()
    {
        anim.SetBool("IsLaugh",false);
    }
}
