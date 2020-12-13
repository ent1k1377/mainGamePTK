using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sliderr : MonoBehaviour
{
    public TextMeshProUGUI text;
    Slider sl;
    float volume = 1f;
    public string namePrefs;

    private void Awake()
    {
        sl = GetComponent<Slider>();
        if (PlayerPrefs.HasKey(namePrefs))
        {
            print(1);
            volume = PlayerPrefs.GetFloat(namePrefs);
        }
        PlayerPrefs.SetFloat(namePrefs, volume);
        sl.value = PlayerPrefs.GetFloat(namePrefs);
    }

    void Start()
    {

    }

    // Update is called once per frame
    public void SetVolume()
    {
        text.text = Convert.ToInt32((PlayerPrefs.GetFloat(namePrefs) * 100)).ToString("");
        PlayerPrefs.SetFloat(namePrefs, sl.value);
    }
}
