using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuController : MonoBehaviour
{
    [Header("Levels To Load")]
    public string _scene1, _scene2, _scene3, _scene4;

    [Header("onClick Game Object")]
    public GameObject mainMenuContainer, startGameDialog, optionDialog, instructionDialog;

    [Header("Buttons")]
    public Button startGameBtn, optionBtn, startGameBackBtn, optionBackBtn, instructionBackBtn;

    public static MenuController instance;

    [Header("Toggle Buttons")]
    public Toggle musicToggle, soundToggle;

    private AudioSource backgroundMusic;

    [HideInInspector]
    public string currentGameScene;

    void Awake()
    {
        MakeInstance();

    }

    void Update()
    {
        backgroundMusic = GameObject.Find("Backgroud Music").GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("musicOn") || PlayerPrefs.GetInt("musicOn") == 1)
        {
            musicToggle.isOn = true;
        }
        else
        {
            musicToggle.isOn = false;
        }
        if (!PlayerPrefs.HasKey("soundOn") || PlayerPrefs.GetInt("soundOn") == 1)
        {
            soundToggle.isOn = true;
        }
        else
        {
            soundToggle.isOn = false;
        }



    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    IEnumerator LoadScene(String _scene)
    {
        AudioManager.instance.Play_ClickSound();
        currentGameScene = _scene;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(_scene);
    }

    public void GoToScene1()
    {
        StartCoroutine(LoadScene(_scene1));
        // SceneManager.LoadScene(_scene1); //Rocky Ridge
    }

    public void GoToScene2()
    {
        StartCoroutine(LoadScene(_scene2));
        // SceneManager.LoadScene(_scene2); //Groovy Grassland
    }

    public void GoToScene3()
    {
        StartCoroutine(LoadScene(_scene3));
        // SceneManager.LoadScene(_scene3); //Frosty Field
    }

    public void GoToScene4()
    {
        StartCoroutine(LoadScene(_scene4));
        // SceneManager.LoadScene(_scene4); //Volcanic Valley
    }

    public void SaveSound()
    {
        PlayerPrefs.SetInt("soundOn", soundToggle.isOn ? 1 : 0);
        VolumeApply();
    }
    public void SaveMusic()
    {
        PlayerPrefs.SetInt("musicOn", musicToggle.isOn ? 1 : 0);
        VolumeApply();
    }
    public void VolumeApply()
    {
        // AudioListener.volume = PlayerPrefs.GetInt("soundOn");
        backgroundMusic.mute = PlayerPrefs.GetInt("musicOn") == 1 ? false : true;
    }

    public void StartGameOnClicked()
    {
        AudioManager.instance.Play_ClickSound();
        mainMenuContainer.SetActive(false);
        startGameDialog.SetActive(true);
    }

    public void OptionOnClicked()
    {
        AudioManager.instance.Play_ClickSound();
        mainMenuContainer.SetActive(false);
        optionDialog.SetActive(true);
    }

    public void InstructionOnClicked()
    {
        AudioManager.instance.Play_ClickSound();
        mainMenuContainer.SetActive(false);
        instructionDialog.SetActive(true);
    }

    public void StartGameBackOnClicked()
    {
        AudioManager.instance.Play_ClickSound();
        mainMenuContainer.SetActive(true);
        startGameDialog.SetActive(false);
    }

    public void OptionBackOnClicked()
    {
        AudioManager.instance.Play_ClickSound();
        mainMenuContainer.SetActive(true);
        optionDialog.SetActive(false);
    }

    public void InstructionBackOnClicked()
    {
        AudioManager.instance.Play_ClickSound();
        mainMenuContainer.SetActive(true);
        instructionDialog.SetActive(false);
    }

    public void ExitBtn()
    {
        // EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
