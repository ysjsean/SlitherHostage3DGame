using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BodyMovement : MonoBehaviour
{
    [HideInInspector]
    public float Speed;
    public Vector3 BodyTarget;

    [HideInInspector]
    public int index;
    public SnakeMovement SnakeHead;
    public GameObject BodyTargetObj;

    void Start()
    {
        SnakeHead = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<SnakeMovement>();
        Speed = SnakeHead.Speed;
        BodyTargetObj = SnakeHead.BodyObjects[SnakeHead.BodyObjects.Count - 2];
        index = SnakeHead.BodyObjects.IndexOf(gameObject);
    }

    void Update()
    {
        if (!SnakeHead.isGameOver && SnakeHead.isGame_started)
        {
            BodyTarget = BodyTargetObj.transform.position;
            transform.LookAt(BodyTarget);
            transform.position = Vector3.Lerp(transform.position, BodyTarget, Time.deltaTime * Speed);

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(UnityEngine.Vector3.forward * 3.0f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(UnityEngine.Vector3.forward * -3.0f * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            if (index > 2)
            {
                //Application.LoadLevel(Application.loadedLevel);
                StartCoroutine(GameOver());
            }
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
