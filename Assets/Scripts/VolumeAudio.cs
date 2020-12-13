using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeAudio : MonoBehaviour
{
    public string namePrefs;

    private void Start()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat(namePrefs);
    }

    private void Update()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat(namePrefs);
    }



}
