using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    private Animator animator;

    

    private void Awake()
    {
        animator = GetComponent<Animator>();


        float randomDelay = Random.Range(0f,2f);

        Invoke("StartFlameAgain", randomDelay);
    }




    private void StartFlameAgain()
    {
        animator.SetTrigger("startFlame");
    }




}
