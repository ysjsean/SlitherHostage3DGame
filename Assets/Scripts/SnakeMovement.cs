using System.Numerics;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour
{
    public static SnakeMovement instance;

    [HideInInspector]
    public float Speed;

    [HideInInspector]
    public float RotationSpeed;
    public List<GameObject> BodyObjects = new List<GameObject>();

    [HideInInspector]
    public float z_offset = 0.5f;
    public GameObject BodyPrefab;
    public Text ScoreText;
    private int nextLevelScore;
    private int nextSpeedScore;
    public int score = 0;
    public int stage = 1;

    public GameObject Monster;

    [HideInInspector]
    public bool isGameOver;

    // [HideInInspector]
    // public bool isThereAMonster;

    public GameObject timerObject;
    private Text timer_Text;

    public GameObject stageObject;
    private Text stage_Text;
    public GameObject victoryObject;

    [HideInInspector]
    public bool isGame_started = false;

    public Text timeText;
    private float timeRemaining;
    private bool timerIsRunning = false;

    [HideInInspector]
    public bool isVictory = false;
    void Awake()
    {
        MakeInstance();
        timer_Text = timerObject.GetComponent<Text>();
        stage_Text = stageObject.GetComponent<Text>();

    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        stage_Text.text = "Stage " + stage;
        StartCoroutine(Countdown(3));
    }

    IEnumerator Countdown(int seconds)
    {
        timerObject.SetActive(true);
        int count = seconds;
        timer_Text.text = "Stage " + stage;
        yield return new WaitForSeconds(1);

        while (count > 0)
        {
            timer_Text.text = "" + count;
            yield return new WaitForSeconds(1);
            count--;
        }

        timer_Text.text = "GO!!!";
        yield return new WaitForSeconds(1);

        if (count == 0)
        {
            timerObject.SetActive(false);
            StartGame();
        }

    }

    void StartGame()
    {
        if (stage == 1)
            BodyObjects.Add(gameObject);

        nextLevelScore = 10;
        nextSpeedScore = 2;
        RotationSpeed = 150.0f;
        timeRemaining = 90f;
        isGame_started = true;
        isGameOver = false;
        timerIsRunning = true;
        // isThereAMonster = false;

        switch (stage)
        {
            case 1:
                Speed = 2.5f;
                break;
            case 2:
                Speed = 3.5f;
                break;
            case 3:
                Speed = 4.5f;
                break;
            default:
                Speed = 4.5f;
                break;
        }

        if (stage > 1)
        {
            Instantiate(Monster, new UnityEngine.Vector3(0f, 0f, 0f), UnityEngine.Quaternion.identity);
            // isThereAMonster = true;
        }
    }

    void StopGame()
    {
        if (timeRemaining > 0)
        {
            if (stage <= 3)
            {
                isGame_started = false;
                Speed = 0f;
                score = 0;
                Start();
            }
            else
                Victory();
        }
        else
        {
            StartCoroutine(GameOver());
        }

    }

    void Victory()
    {
        isVictory = true;
        victoryObject.SetActive(true);
        PortalController.instance.ActivatePortal();
    }

    IEnumerator GameOver()
    {
        isGameOver = true;
        timerObject.SetActive(true);
        timer_Text.text = "Times Up!!!";

        yield return new WaitForSeconds(1);
        GameOverController.instance.GameOver();
    }

    void Update()
    {
        if (!isGameOver && isGame_started)
        {
            ScoreText.text = "Score: " + score + "/" + nextLevelScore;
            if (score == nextLevelScore && stage <= 3)
            {
                timerIsRunning = false;
                stage++;
                StopGame();
            }

            if (score == nextSpeedScore)
            {
                Speed += 0.5f;
                nextSpeedScore += 2;
            }

            transform.Translate(UnityEngine.Vector3.forward * Speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) //Turn right
            {
                transform.Rotate(UnityEngine.Vector3.up * RotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //Turn left
            {
                transform.Rotate(UnityEngine.Vector3.up * -1 * RotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) //Temporary speed boost
            {
                transform.Translate(UnityEngine.Vector3.forward * 3.0f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) //Brake
            {
                transform.Translate(UnityEngine.Vector3.forward * -2.0f * Time.deltaTime);
            }

            if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    DisplayTime(timeRemaining);
                }
                else
                {
                    Debug.Log("Time has run out!");
                    timeRemaining = 0;
                    timerIsRunning = false;
                    StopGame();
                }
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        if (minutes >= 0 && seconds >= 0)
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddBody()
    {
        score++;
        UnityEngine.Vector3 newBodyPos = BodyObjects[BodyObjects.Count - 1].transform.position;
        newBodyPos.z -= z_offset;
        BodyObjects.Add(GameObject.Instantiate(BodyPrefab, newBodyPos, UnityEngine.Quaternion.identity) as GameObject);
    }
}
