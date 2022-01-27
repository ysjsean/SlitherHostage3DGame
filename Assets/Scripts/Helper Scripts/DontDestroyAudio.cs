using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
    void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Background_Music");
        if (musicObj.Length > 1)
            Destroy(transform.gameObject);
        DontDestroyOnLoad(transform.gameObject);
    }
}
