using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private List<GameObject> rounds = new List<GameObject>();
    public GameObject dummyBall;
    public Image[] balls;
    public GameObject[] hearts;
    public GameObject btn;
    public Text totalBallsText;
    public Text countBallsText;
    public Text levelCompleteText;
    public GameObject levelComplete;
    public GameObject failScreen;
    public GameObject startGameScreen;

    public static float rotationSpeed = 100f;
    public static int currentCircleNo;
    public static Color oneColor;
    
    public static int circleCount;

    private float speed = 100;
    private int ballsCount;
    public static int circleNo;
    private int heartNo;
    private Color[] ChangingColors;
    private bool gameFail;

    public SpriteRenderer spr;
    public Material splashMat;
    public LevelsHandlerScript levelsHandlerScript;

    private void Start()
    {
        levelsHandlerScript = GetComponent<LevelsHandlerScript>();
        ResetGame();  
    }

    public void ResetGame()
    {
        circleCount = 1;
        ChangingColors = ColorScript.colorArray;
        oneColor = ChangingColors[0];
        spr.color = oneColor;
        splashMat.color = oneColor;

        ChangeBallsCount();

        GameObject goRound = Instantiate(rounds[Random.Range(0, rounds.Count)], new Vector3(0, 20, 23), Quaternion.identity);
        goRound.name = ("Circle" + circleNo);

        ballsCount = LevelsHandlerScript.ballsCount;

        currentCircleNo = circleNo;
        
        if(heartNo == 0)
        {
            PlayerPrefs.GetInt("hearts", 1);
        }
        heartNo = PlayerPrefs.GetInt("hearts");
        for(int i = 0; i < heartNo; i++)
        {
            hearts[i].SetActive(true);
        }
        circleNo = 0;
        MakeHurdles();
    }

    public void FailGame()
    {
        gameFail = true;
        Invoke("FailScreen", 1);
        btn.SetActive(false);
        StopCircle();
    }

    public void StopCircle()
    {
        GameObject goCircle = GameObject.Find("Circle" + circleNo);
        goCircle.transform.GetComponent<MonoBehaviour>().enabled = false;
        goCircle.GetComponent<Animator>().enabled = false;

    }

    public void FailScreen()
    {
        failScreen.SetActive(true);
    }

    public void DeleteAllCircles()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("circle");
        for(int i = 0; i < array.Length; i++)
        {
            Destroy(array[i].gameObject);
        }
        gameFail = false;
        levelsHandlerScript.UpgradeLevel();
        ResetGame();
    }

    public void HeartsLow()
    {
        heartNo--;
        PlayerPrefs.SetInt("hearts", heartNo);
    }

    public void HitBall()
    {
        if(ballsCount <= 0)
        {
            StartCoroutine(HideBtn());
            this.Invoke("MakeaNewCircle", 0.4f);
        }

        ballsCount--;

        if (ballsCount >= 0)
        {
            balls[ballsCount].enabled = false;
        }

        ballsCount--;

        GameObject goBall = Instantiate(ball, new Vector3(0, 0, -8), Quaternion.identity);
        goBall.GetComponent<MeshRenderer>().material.color = oneColor;
        goBall.GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
    }

    public void ChangeBallsCount()
    {
        ballsCount = LevelsHandlerScript.ballsCount;
        dummyBall.GetComponent<MeshRenderer>().material.color = oneColor;

        totalBallsText.text = "" + LevelsHandlerScript.totalCircles;
        countBallsText.text = "" + circleCount;

        for(int i = 0; i < balls.Length; i++)
        {
            balls[i].enabled = false;
        }

        for(int j = 0; j < ballsCount; j++)
        {
            balls[j].enabled = true;
            balls[j].color = oneColor;
        }

    }

    private void MakeaNewCircle()
    {
        if (circleCount >= LevelsHandlerScript.totalCircles && !gameFail) 
        {
            StartCoroutine(LevelCompleteScreen());
        }

        else
        {
            
            GameObject[] array = GameObject.FindGameObjectsWithTag("circle");
            GameObject goCircle = GameObject.Find("Circle" + circleNo);
            for (int i = 0; i < 24; i++)
            {
                goCircle.transform.GetChild(i).gameObject.SetActive(false);
            }
            goCircle.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.oneColor;

            if (goCircle.GetComponent<Animator>())
            {
                goCircle.GetComponent<Animator>().enabled = false;
            }
            
            for (int i = 0; i < array.Length; i++)
            {
                array[i].transform.Translate(new Vector3(0, -2.98f, 0));
            }
            
            circleNo++;

            GameObject goRound = Instantiate(rounds[Random.Range(0, rounds.Count)], new Vector3(0, 20, 23), Quaternion.identity);
            goRound.name = "Circle" + circleNo;
            currentCircleNo = circleNo;


            ballsCount = LevelsHandlerScript.ballsCount;
            circleCount++;
            oneColor = ChangingColors[circleNo];
            spr.color = oneColor;
            splashMat.color = oneColor;

            MakeHurdles();
            ChangeBallsCount();
        }
    }

    void MakeHurdles()
    {
        if(circleNo == 0)
        {
            levelsHandlerScript.MakeHurdles1();
        }

        if (circleNo == 1)
        {
            levelsHandlerScript.MakeHurdles2();
        }

        if (circleNo == 2)
        {
            levelsHandlerScript.MakeHurdles3();
        }

        if (circleNo == 3)
        {
            levelsHandlerScript.MakeHurdles4();
        }

        if (circleNo == 4)
        {
            levelsHandlerScript.MakeHurdles5();
        }

        if (circleNo == 5)
        {
            levelsHandlerScript.MakeHurdles5();
        }

        if (circleNo == 6)
        {
            levelsHandlerScript.MakeHurdles5();
        }
    }

    IEnumerator HideBtn()
    {
        if (!gameFail)
        {
            btn.SetActive(false);
            yield return new WaitForSeconds(1);
            btn.SetActive(true);
        }
    }

    IEnumerator LevelCompleteScreen()
    {
        gameFail = true;
        GameObject oldCircle = GameObject.Find("Circle" + circleNo);
        for(int i = 0; i < 24; i++)
        {
            oldCircle.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;   
        }
        oldCircle.transform.GetChild(24).gameObject.GetComponent<MeshRenderer>().material.color = oneColor;
        oldCircle.transform.GetComponent<MonoBehaviour>().enabled = false;
        oldCircle.GetComponent<Animator>().enabled = false;
        btn.SetActive(false);
        yield return new WaitForSeconds(2);
        levelComplete.SetActive(true);
        levelCompleteText.text = "" + LevelsHandlerScript.currentLevel;
        yield return new WaitForSeconds(1);
        GameObject[] oldCircles = GameObject.FindGameObjectsWithTag("circle");
        for(int j = 0; j < oldCircles.Length; j++)
        {
            Destroy(oldCircles[j].gameObject);
        }
        circleNo = 0;
        yield return new WaitForSeconds(1);
        int currentLevel = PlayerPrefs.GetInt("C_Level");
        currentLevel++;
        PlayerPrefs.SetInt("C_Level", currentLevel);
        levelsHandlerScript.UpgradeLevel();
        ResetGame();
        levelComplete.SetActive(false);
        startGameScreen.SetActive(true);
        gameFail = false;

    }

}
