using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    Animator anim_heart1;
    Animator anim_heart2;
    Animator anim_heart3;

    public GameObject[] heartGO;
    public Animator[] animHeartGO;
    int num_health = 3;

    void Start()
    {
        anim_heart1 = heart1.GetComponent<Animator>();
        anim_heart2 = heart2.GetComponent<Animator>();
        anim_heart3 = heart3.GetComponent<Animator>();
        heartGO = new GameObject[3] { heart1, heart2, heart3 };
        animHeartGO = new Animator[3] { anim_heart1, anim_heart2, anim_heart3 };
    }

    // Update is called once per frame
    void Update()
    {
        if (num_health != HeroMove.num_health)
        {
            num_health = HeroMove.num_health;
            animHeartGO[num_health].Play("heart_die");
            //Destroy(heartGO[num_health]);
            
        }
    }
}
