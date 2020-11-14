using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormEnemy : MonoBehaviour
{
    public float leftBorder;
    public float rightBorder;

    float speed = 0.2f;
    public bool moveRight = true;
    Vector2 pos;

    Animator anim;
    public bool death = false;

    public HeroMove HM;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (death)
        {
            anim.SetBool("onDeath", death);
            Destroy(gameObject, 1f);
            return;
        }


        pos = gameObject.GetComponent<Transform>().position;

        if (pos.x > rightBorder) speed = -Math.Abs(speed);
        else if(pos.x < leftBorder) speed = Math.Abs(speed);

        gameObject.GetComponent<Transform>().position = new Vector2(pos.x + speed * Time.deltaTime, pos.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "sword")
        {
            death = true;
        }
        else if(col.tag == "pers")
        {
            HM.CheckHealth();
        }
    }



}
