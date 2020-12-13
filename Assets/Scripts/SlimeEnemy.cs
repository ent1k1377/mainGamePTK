using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    public float leftBorder;
    public float rightBorder;

    public float speed = 0.2f;
    public int moveRight = -1;
    Vector2 pos;

    Animator anim;
    public bool death = false;

    public HeroMove HM;


    void Start()
    {
        gameObject.transform.localScale = new Vector2(moveRight, 1);
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!death)
        {
            if (col.tag == "sword")
            {
                death = true;
            }
            else if (col.tag == "pers")
            {
                HM.CheckHealth();
            }
        }

    }

    void Move()
    {
        if (death)
        {
            anim.SetBool("onDeath", death);
            Destroy(gameObject, 1f);
            return;
        }


        pos = gameObject.GetComponent<Transform>().position;
        if (pos.x > rightBorder)
        {
            speed = -Math.Abs(speed);
            gameObject.transform.localScale = new Vector2(1, 1);
        }
        else if (pos.x < leftBorder)
        {
            speed = Math.Abs(speed);
            gameObject.transform.localScale = new Vector2(-1, 1);
        }

        gameObject.GetComponent<Transform>().position = new Vector2(pos.x + speed * Time.deltaTime, pos.y);
    }
}