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

    void AddNewFood()
    {
        RandomPos();
        curFood = GameObject.Instantiate(foodPrefab, curPos, Quaternion.identity) as GameObject;
    }

    void RandomPos()
    {
        curPos = new Vector3(Random.Range(LengthSizeX * -1, LengthSizeX), 0.36f, Random.Range(LengthSizeZ * -1, LengthSizeZ));
    }

    void Update()
    {
        if (!curFood)
        {
            AddNewFood();
        }
        else
        {
            return;
        }
    }
}
