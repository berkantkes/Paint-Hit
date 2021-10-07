using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsHandlerScript : MonoBehaviour
{
    public static int currentLevel;
    public static int ballsCount = 3;
    public static int totalCircles;

    private void Start()
    {
        PlayerPrefs.SetInt("C_Level", 1);

        if (PlayerPrefs.GetInt("firstTime1",0) == 0)
        {
            PlayerPrefs.SetInt("firstTime1", 1);
            PlayerPrefs.SetInt("C_Level", 1);
        }
        UpgradeLevel();
    }

    public void UpgradeLevel()
    {
        currentLevel = PlayerPrefs.GetInt("C_Level" , 1);

        if(currentLevel == 1)
        {
            ballsCount = 3;
            totalCircles = 2;
        }
        if (currentLevel == 2)
        {
            ballsCount = 3;
            totalCircles = 3;
        }

        if (currentLevel == 3)
        {
            ballsCount = 3;
            totalCircles = 4;
        }

        if (currentLevel == 5)
        {
            ballsCount = 3;
            totalCircles = 5;
        }

        if (currentLevel == 6)
        {
            ballsCount = 3;
            totalCircles = 5;
        }

        if (currentLevel == 7)
        {
            ballsCount = 3;
            totalCircles = 5;
        }

        if (currentLevel >=8 && currentLevel <=12)
        {
            ballsCount = 4;
            totalCircles = 5;
        }

        if (currentLevel > 12 && currentLevel <= 20)
        {
            ballsCount = 4;
            totalCircles = 6;
            BallHandler.rotationSpeed = 120f;
        }

        if (currentLevel > 20)
        {
            ballsCount = 5;
            totalCircles = 7;
            BallHandler.rotationSpeed = 140f;
        }
    }

    public void MakeHurdles1()
    {
        GameObject goHurdle = GameObject.Find("Circle" + BallHandler.currentCircleNo);

        int index = Random.Range(1, 3);

        goHurdle.transform.GetChild(index).gameObject.GetComponent<MeshRenderer>().enabled = true;
        goHurdle.transform.GetChild(index).gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.oneColor;
        goHurdle.transform.GetChild(index).gameObject.tag = "red";
    }

    public void MakeHurdles2()
    {
        GameObject goHurdle = GameObject.Find("Circle" + BallHandler.currentCircleNo);

        int [] array = new int[] 
        {
            Random.Range(1,3),
            Random.Range(15,17)
        };

        for(int i = 0; i < array.Length; i++)
        {
            goHurdle.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            goHurdle.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.oneColor;
            goHurdle.transform.GetChild(array[i]).gameObject.tag = "red";
        }

    }

    public void MakeHurdles3()
    {
        GameObject goHurdle = GameObject.Find("Circle" + BallHandler.currentCircleNo);

        int[] array = new int[]
        {
            Random.Range(1,3),
            Random.Range(4,6),
            Random.Range(18,20)
        };

        for (int i = 0; i < array.Length; i++)
        {
            goHurdle.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            goHurdle.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.oneColor;
            goHurdle.transform.GetChild(array[i]).gameObject.tag = "red";
        }

    }

    public void MakeHurdles4()
    {
        GameObject goHurdle = GameObject.Find("Circle" + BallHandler.currentCircleNo);

        int[] array = new int[]
        {
            Random.Range(1,3),
            Random.Range(4,6),
            Random.Range(15,17),
            Random.Range(22,24)
        };

        for (int i = 0; i < array.Length; i++)
        {
            goHurdle.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            goHurdle.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.oneColor;
            goHurdle.transform.GetChild(array[i]).gameObject.tag = "red";
        }

    }

    public void MakeHurdles5()
    {
        GameObject goHurdle = GameObject.Find("Circle" + BallHandler.currentCircleNo);

        int[] array = new int[]
        {
            Random.Range(1,3),
            Random.Range(4,6),
            Random.Range(11,13),
            Random.Range(8,10),
            Random.Range(15,17)
        };

        for (int i = 0; i < array.Length; i++)
        {
            goHurdle.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().enabled = true;
            goHurdle.transform.GetChild(array[i]).gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.oneColor;
            goHurdle.transform.GetChild(array[i]).gameObject.tag = "red";
        }

    }

}
