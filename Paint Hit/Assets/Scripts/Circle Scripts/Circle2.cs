using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle2 : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(SpinCircle2());
    }
    
    IEnumerator SpinCircle2()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger("circle2");
    }
}
