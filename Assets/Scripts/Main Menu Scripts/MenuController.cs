using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuController : MonoBehaviour
{
    [Header("Levels To Load")]
    public string _scene1, _scene2, _scene3, _scene4, _backToMenu, _gameOver;

    public static MenuController instance;

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

    public void GoToScene1()
    {
        SceneManager.LoadScene(_scene1); //Rocky Ridge
    }

    public void GoToScene2()
    {
        SceneManager.LoadScene(_scene2); //Groovy Grassland
    }

    public void GoToScene3()
    {
        SceneManager.LoadScene(_scene3); //Frosty Field
    }

    public void GoToScene4()
    {
        SceneManager.LoadScene(_scene4); //Volcanic Valley
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(_backToMenu);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void ExitBtn()
    {
        EditorApplication.isPlaying = false;
    }
}
