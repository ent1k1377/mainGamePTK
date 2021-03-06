﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public Rigidbody2D HeroRB2D;
    public LayerMask HeroMask;
    public Transform HeroCheck;
    public Transform HeroCheck2;
    public Transform HeroCheck3;
    bool onHero;
    public int force_jump = 15;

    public AudioSource jumpA;
    void Update()
    {
        onHero = Physics2D.OverlapBox(HeroCheck.position, new Vector2(0, 0.2f), 0, HeroMask) || 
                Physics2D.OverlapBox(HeroCheck2.position, new Vector2(0, 0.2f), 0, HeroMask) ||
                Physics2D.OverlapBox(HeroCheck3.position, new Vector2(0, 0.2f), 0, HeroMask);
        if (onHero)
        {
            jumpA.Play();
            HeroRB2D.velocity = new Vector2(HeroRB2D.velocity.x, 0);
            HeroRB2D.AddForce(new Vector2(0, force_jump), ForceMode2D.Impulse);
        }
    }
}
