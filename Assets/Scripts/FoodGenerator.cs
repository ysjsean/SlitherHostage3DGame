using System.Net.NetworkInformation;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodGenerator : MonoBehaviour
{
    public float LengthSizeX = 13.2f;
    public float LengthSizeZ = 8.8f;
    public GameObject foodPrefab;
    public Vector3 curPos;
    public GameObject curFood;

    private Collider[] hitColliders;


    void AddNewFood()
    {
        while (true)
        {
            RandomPos();
            hitColliders = Physics.OverlapSphere(curPos, 0.5f);
            if (hitColliders.Length == 1)
            {
                break;
            }
        }


        curFood = GameObject.Instantiate(foodPrefab, curPos, Quaternion.identity) as GameObject;
    }

    void RandomPos()
    {
        curPos = new Vector3(Random.Range(LengthSizeX * -1, LengthSizeX), 0.36f, Random.Range(LengthSizeZ * -1, LengthSizeZ));
    }

    void Update()
    {
        if (!curFood && SnakeMovement.instance.isGame_started && !SnakeMovement.instance.isGameOver && !SnakeMovement.instance.isVictory)
        {
            AddNewFood();
        }
        else
        {
            return;
        }
    }
}
