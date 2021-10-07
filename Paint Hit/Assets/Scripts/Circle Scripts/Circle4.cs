using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle4 : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(SpinCircle4());
    }

    IEnumerator SpinCircle4()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetTrigger("circle4");
    }
}

