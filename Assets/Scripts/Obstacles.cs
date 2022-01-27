using UnityEngine;
using System.Collections;

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
        yield return new WaitForSeconds(1);

        MenuController.instance.GameOver();
    }
}
