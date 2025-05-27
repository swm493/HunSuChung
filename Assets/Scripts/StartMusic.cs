using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    GameObject[] BackgroundMusics;
    AudioSource audioSource;

    void Awake()
    {
        BackgroundMusics = GameObject.FindGameObjectsWithTag("Music");

        if (BackgroundMusics.Length >= 2)
            Destroy(this.gameObject);

        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }


}