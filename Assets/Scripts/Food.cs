using System.Numerics;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            AudioManager.instance.Play_PickUpSound(other.GetComponent<SnakeMovement>().transform);
            other.GetComponent<SnakeMovement>().AddBody();
            Destroy(gameObject);
        }
    }
}
