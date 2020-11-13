using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool leftTurned = true;
    public Sprite LTL;
    public Sprite LTR;
    public Animator animBoard;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (leftTurned)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = LTL;
            animBoard.SetBool("onBoard", false);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = LTR;
            animBoard.SetBool("onBoard", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "sword")
        {
            leftTurned = !leftTurned;
        }
    }
}
