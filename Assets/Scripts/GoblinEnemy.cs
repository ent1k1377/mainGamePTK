using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEnemy : MonoBehaviour
{
    Animator anim;

    public int num_health = 5;
    bool onHero;
    public float n;
    public bool rigthFace;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        if (!rigthFace) gameObject.transform.localScale = new Vector2(-1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        CheckHero();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "sword" && !anim.GetCurrentAnimatorStateInfo(0).IsName("goblin_hit"))
        {
            print(321);
            StartCoroutine(TimerHit());
        }
    }
    
    IEnumerator TimerHit()
    {
        anim.SetBool("onHit", true);
 
        num_health -= 1;
        
        
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("goblin_hit"))
        {
            yield return new WaitForSeconds(0.1f);
        }

        anim.SetBool("onHit", false);
    }

    void CheckHero()
    {
        onHero = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(gameObject.transform.localScale.x, 0), n, LayerMask.GetMask("Pers"));
        if (hit.collider != null) onHero = true;
        anim.SetBool("onHero", onHero);
        
    }

    void CheckHealth()
    {
        if (num_health <= 0)
        {
            Destroy(gameObject, 1f);
        }
        anim.SetInteger("numHealth", num_health);
    }

}
