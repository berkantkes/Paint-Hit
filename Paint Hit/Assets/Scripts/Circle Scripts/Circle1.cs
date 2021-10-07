using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle1 : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * BallHandler.rotationSpeed);
    }
    public void AnimationFinish()
    {
        this.GetComponent<Animator>().enabled = false;
    }
}
