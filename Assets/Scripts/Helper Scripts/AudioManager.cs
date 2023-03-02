using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip pickUp_Sound, dead_Sound, click_Sound;


    // Start is called before the first frame update
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

    public void Play_PickUpSound(Transform snakeHead)
    {
        if (!PlayerPrefs.HasKey("soundOn") || PlayerPrefs.GetInt("soundOn") == 1)
            AudioSource.PlayClipAtPoint(pickUp_Sound, snakeHead.position);
    }

    public void Play_DeadSound(Transform snakeHead)
    {
        if (!PlayerPrefs.HasKey("soundOn") || PlayerPrefs.GetInt("soundOn") == 1)
            AudioSource.PlayClipAtPoint(dead_Sound, snakeHead.position);
    }

    public void Play_ClickSound()
    {
        if (!PlayerPrefs.HasKey("soundOn") || PlayerPrefs.GetInt("soundOn") == 1)
            AudioSource.PlayClipAtPoint(click_Sound, new Vector3(5, 1, 2));
    }
}
