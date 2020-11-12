using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public GameObject Button;
    Animator animButton;

    public GameObject Wall;
    Animator animWall;

    public bool onButton;
    public LayerMask Button_LM;
    public Transform ButtonCheck;
    public float size_x_collider = 0.2f;
    void Start()
    {
        animButton = Button.GetComponent<Animator>();
        animWall = Wall.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ButtonChecking();
    }
    void ButtonChecking()
    {
        onButton = Physics2D.OverlapBox(ButtonCheck.position, new Vector2(0, size_x_collider), 0, Button_LM);
        animButton.SetBool("onButton", onButton);
        animWall.SetBool("onButton", onButton);
    }
}
