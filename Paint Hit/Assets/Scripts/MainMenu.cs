using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image background;
    public Sprite[] spr;
    public GameObject pauseScreen;

    void Start() 
    {
        background.sprite = spr[Random.Range(0, spr.Length)];
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false); 
    }

}
