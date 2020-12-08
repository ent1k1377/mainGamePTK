using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public int number_level;
    public TextMeshProUGUI text_coin;
    public static string text;
    public SpriteRenderer Lock;
    void Start()
    {
        StartCoroutine(SelectLevelCoins(number_level));
    }


    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SceneManager.LoadScene(number_level + 1);
        }
        
    }

    public IEnumerator SelectLevelCoins(int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id);

        WWW www = new WWW("GameDB.local/selectLevelCoins.php", form);
        while (!www.isDone)
        {
            continue;
        }
        yield return www.text;
        text_coin.text = www.text;


    }
}
