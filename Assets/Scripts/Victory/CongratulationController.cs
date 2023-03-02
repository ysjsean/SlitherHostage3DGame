using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CongratulationController : MonoBehaviour
{
    [Header("Levels To Load")]
    public string _backToMenu;

    public static CongratulationController instance;

    private MenuController menuController;
    private string currentGameScene;

    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (MenuController.instance.currentGameScene != null)
            currentGameScene = MenuController.instance.currentGameScene;
    }

    public void PlayAgain()
    {
        AudioManager.instance.Play_ClickSound();
        if (!string.IsNullOrEmpty(currentGameScene))
        {
            SceneManager.LoadScene(currentGameScene);
        }
    }

    public void BackToMenu()
    {
        StartCoroutine(OnClickDelay(_backToMenu));
    }

    IEnumerator OnClickDelay(String sceneToLoad)
    {
        AudioManager.instance.Play_ClickSound();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Congrats()
    {
        SceneManager.LoadScene("Congratulation");
    }
}
