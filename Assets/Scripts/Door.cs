using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int indexNextScene;
    public Animator animHero;
    public HeroMove HM;
    public LayerMask HeroLM;




    private void Update()
    {
        if (Physics2D.OverlapBox(transform.position, new Vector2(0, 0.5f), 0, HeroLM))
        {
            CheckPressedButton();
        }
    }


    void CheckPressedButton()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(LoadScene());
        }
    }
    IEnumerator LoadScene()
    {
        StartCoroutine(WebManager.ConnectDB(indexNextScene - 1, HeroMove.num_coins, 1, 0, Math.Abs(Convert.ToInt32(Timer.minutes * 60 + Timer.seconds))));
        HM.enabled = false;
        animHero.SetBool("onDeath", true);
        animHero.SetBool("onDeathAstral", false);
        animHero.Play("hero_death");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(indexNextScene + 1);
    }
}
