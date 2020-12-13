using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gear : MonoBehaviour
{
    public GameObject gearImage;
    int indexNextScene;
    public GameObject ContinieImage;
    public GameObject NextLevelImage;
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void F()
    {
        print(321);
    }
    public void GearWindow(int ids=-10)
    {
        indexNextScene = ids;
        if (ids == -10)
        {
            NextLevelImage.SetActive(false);
        }
        else
        {
            ContinieImage.SetActive(false);
        }
        gearImage.SetActive(false);
        Time.timeScale = 0;
        gameObject.GetComponent<Canvas>().enabled = true;
    }
    public void MenuWindow()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGearWindow()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        gearImage.SetActive(true);
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(indexNextScene + 1);
    }


}
