using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{
    [HideInInspector]
    public SnakeMovement SnakeHead;
    void Start()
    {
        SnakeHead = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<SnakeMovement>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            //Application.LoadLevel(Application.loadedLevel);
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        SnakeHead.isGameOver = true;
        AudioManager.instance.Play_DeadSound(SnakeHead.transform);

        yield return new WaitForSeconds(1);
        GameOverController.instance.GameOver();
    }
}
