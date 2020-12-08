using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public static float seconds;
    public static int minutes;
    public TextMeshProUGUI timeText;
    string formatTime = "00";
    void Start()
    {
        seconds = 0;
        minutes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 60)
        {
            minutes += 1;
            seconds -= 60;
        }
        timeText.text = minutes.ToString(formatTime) + $":{Mathf.Round(seconds).ToString(formatTime)}";
    }
}
