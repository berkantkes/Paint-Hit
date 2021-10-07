using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle5 : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(SpinCircle5());
    }

    IEnumerator SpinCircle5()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger("circle5");
    }
}
