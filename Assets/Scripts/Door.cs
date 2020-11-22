using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int indexScene;
    public Animator animHero;
    public HeroMove HM;
    private void OnTriggerStay2D(Collider2D col)
    {
        print(1);
        if (col.tag == "pers")
        {
            print(2);
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
        HM.enabled = false;
        animHero.SetBool("onDeath", true);
        animHero.SetBool("onDeathAstral", false);
        animHero.Play("hero_death");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(indexScene);
    }
}
