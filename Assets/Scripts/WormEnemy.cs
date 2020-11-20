using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormEnemy : MonoBehaviour
{
    public float leftBorder;
    public float rightBorder;

    public float speed = 0.2f;
    public bool moveRight = true;
    Vector2 pos;

    Animator anim;
    public bool death = false;

    public HeroMove HM;
    Rigidbody2D HMRB2;
    public LayerMask Pers;
    public Transform HeroCheck;
    bool onHero;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        HMRB2 = HM.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHero();
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
    void CheckHero()
    {
        onHero = Physics2D.OverlapBox(HeroCheck.position, new Vector2(0, 0.1f), 0, Pers);

        if (onHero && !death)
        {

            if (!HM.onGround && !HM.onPhantom)
            {
                death = true;
                HMRB2.velocity = new Vector2(HMRB2.velocity.x, 0);
                HMRB2.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
            }


        }
    }



}