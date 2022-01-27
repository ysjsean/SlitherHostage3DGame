using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerfollow : MonoBehaviour
{
    public Transform Playerpos;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        Playerpos = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<SnakeMovement>().transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = Playerpos.position;
    }
}
