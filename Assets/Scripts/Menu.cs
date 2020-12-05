﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    public void LevelsWindow()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }
    public void MainWindow()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
