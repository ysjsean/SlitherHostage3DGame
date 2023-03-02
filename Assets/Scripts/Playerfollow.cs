using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerfollow : MonoBehaviour
{
    [HideInInspector]
    public Transform Playerpos;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        Playerpos = GameObject.FindGameObjectsWithTag("SnakeHead")[0].GetComponent<SnakeMovement>().transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if (SnakeMovement.instance.isGame_started)
        {
            agent.isStopped = false;
            agent.destination = Playerpos.position;
        }
        else
        {
            agent.isStopped = true;
        }

    }
}
