using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle3 : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.down * Time.deltaTime * (BallHandler.rotationSpeed +20f ));
    }

    public void AnimationFinish()
    {
        this.GetComponent<Animator>().enabled = false;
    }
}
