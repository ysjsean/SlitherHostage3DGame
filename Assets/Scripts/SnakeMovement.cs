using System.Numerics;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour
{
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
    public int score = 0;

    public GameObject ghost;

    [HideInInspector]
    public bool isGameOver;

    void Start()
    {
        BodyObjects.Add(gameObject);
        Speed = 2.5f;
        nextLevelScore = 2;
        RotationSpeed = 150.0f;
        isGameOver = false;
        // StartCoroutine(SpawnGhost());
    }

    void Update()
    {
        ScoreText.text = "Score: " + score;

        if (!isGameOver)
        {
            if (score == nextLevelScore)
            {
                Speed += 0.5f;
                nextLevelScore += 2;
            }

            if (score == 99)
            {
                SpawnGhost();
            }

            transform.Translate(UnityEngine.Vector3.forward * Speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(UnityEngine.Vector3.up * RotationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(UnityEngine.Vector3.up * -1 * RotationSpeed * Time.deltaTime);
            }
        }

    }

    void SpawnGhost()
    {
        // yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 1.5f));

        // if (score >= 2)
        // {
        Instantiate(ghost, new UnityEngine.Vector3(UnityEngine.Random.Range(0, 0), 0.4f, UnityEngine.Random.Range(0, 0)), UnityEngine.Quaternion.identity);
        // }
    }

    public void AddBody()
    {
        score++;
        UnityEngine.Vector3 newBodyPos = BodyObjects[BodyObjects.Count - 1].transform.position;
        newBodyPos.z -= z_offset;
        BodyObjects.Add(GameObject.Instantiate(BodyPrefab, newBodyPos, UnityEngine.Quaternion.identity) as GameObject);
    }
}
