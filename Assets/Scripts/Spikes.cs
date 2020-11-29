using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public bool onHit;
    Animator anim;
    public float size_raycast = 1f;
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, size_raycast, LayerMask.GetMask("Pers"));

        onHit = false;
        if (hit.collider != null)
        {
            onHit = true;
            this.GetComponent<Rigidbody2D>().simulated = true;
        };
        anim.SetBool("onHit", onHit);

    }
}
