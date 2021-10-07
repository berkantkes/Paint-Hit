using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Text levelNo;
    public Text TargetText;

    private void OnEnable()
    {
        levelNo.text = "" + LevelsHandlerScript.currentLevel;
        TargetText.text = "" + LevelsHandlerScript.totalCircles;
        StartCoroutine(DelayedRemoval());
    }

    IEnumerator DelayedRemoval()
    {
        yield return new WaitForSeconds(1);
        base.gameObject.SetActive(false);
    }
}
