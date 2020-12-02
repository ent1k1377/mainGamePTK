using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class HeroMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed = 25f;
    float stopSpeed;
    public Animator anim;
    public SpriteRenderer sr;
    public bool faceRight = true;
    public float downKey = 0;
    public Ghost ghost;

    public float jumpForce = 800f;
    private bool jumpControl;
    private int jumpIteration = 0;
    public int jumpValueIteration = 60;
    bool velocity;

    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;

    public int lungeImpulse = 500;
    bool lockLunge = true;
    public float lockLungeTime = 0.4f;

    public bool onStone;
    public bool onPush;
    public LayerMask Stone;
    public Transform PushCheck;


    // AUDIO 
    public AudioSource lungeA;
    public AudioSource swordA;
    public AudioSource coinA;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        //transform.position = hero_spawn;
        color.a = 0.4f;
        num_health = 3;
        num_coins = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Death();
        if (onDeath) return;
        Movement();
        Pushing();
        Flip();
        Jump();
        Lunge();
        CheckingGround();
        Sword();
    }
    void Movement()
    {
        downKey = -1;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) 
        {
            ghost.makeGhost = true;
            downKey = 1;
            stopSpeed = speed;
        }
        else
        {
            ghost.makeGhost = false;
            stopSpeed = speed * 0.2f;
        }

        anim.SetFloat("moveX", downKey);
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * stopSpeed, rb.velocity.y);
        
    }
    void Flip()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }
    void Jump()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (onGround) { jumpControl = true; }

        }
        else { jumpControl = false; }
        if (jumpControl)
        {
            if (jumpIteration < jumpValueIteration)
            {
                jumpIteration++;
                rb.AddForce(Vector2.up * jumpForce / jumpIteration);
            }
        }
        else { jumpIteration = 0; }

        velocity = rb.velocity.y >= 0;
        anim.SetBool("velocity", velocity);
    }
    void CheckingGround()
    {
        onGround = Physics2D.OverlapBox(GroundCheck.position, new Vector2(0, checkRadius), 0, Ground) || Physics2D.OverlapBox(GroundCheck.position, new Vector2(0, checkRadius), 0, Stone);
        anim.SetBool("onGround", onGround);
    }
    IEnumerator TimerLunge(Vector2 vect)
    {
        lungeA.Play();
        lockLunge = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
        for (int i = 0; i < 6; i++)
        {
            ghost.makeGhost = true;
            Ghost.ghostDelay = 0.001f;
            rb.AddForce(vect * lungeImpulse/ 5f);
            yield return new WaitForSeconds(0.02f);
        }
        Ghost.ghostDelay = 0.04f;
        Invoke("LungeLock", lockLungeTime);
    }
    void Lunge()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && lockLunge)
        {
            //audio.Play();
            if (faceRight) StartCoroutine(TimerLunge(Vector2.right));
            else StartCoroutine(TimerLunge(Vector2.left));
        }
    }
    void LungeLock()
    {
        lockLunge = true;
    }

    IEnumerator SwordTimer()
    {
        swordA.Play(1);
        anim.SetBool("sword", true);
        yield return new WaitForSeconds(2.4f);
    }

    void Sword()
    {
        anim.SetBool("sword", false);
        if (Input.GetMouseButtonDown(0) && onGround && !anim.GetCurrentAnimatorStateInfo(0).IsName("hero_sword"))
        {
            swordA.Play(1);
            anim.SetBool("sword", true);
            //StartCoroutine(SwordTimer());
        }
        
    }


    public float size_x_collider = 0.11f;
    void Pushing()
    {
        //onStone = Physics2D.OverlapCircle(PushCheck.position, checkRadius, Stone);
        onStone = Physics2D.OverlapBox(PushCheck.position, new Vector2(size_x_collider, 0), 0, Stone);
        onPush = (downKey == 1 && onStone);
        anim.SetBool("onPush", onPush);
    }

    

    public static int num_health;
    Color color = Color.white;

    public static int num_coins;
    Animator anim_coin;
    string coinText = "";
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "gameOver")
        {
            Spawn();
        }
        if (col.gameObject.tag == "trap")
        {
            CheckHealth();
        }
        if (col.gameObject.tag == "coin" && coinText != col.name)
        {
            coinA.Play();
            coinText = col.name;
            num_coins += 1;
            anim_coin = col.gameObject.GetComponent<Animator>();
            anim_coin.Play("coin_pickup");

        }
        
    }

    public void CheckHealth()
    {
        if (num_health > 0)
        {
            if (!onPhantom)
            {
                num_health -= 1;
                Phantom();
                Invoke("Phantom", timePhantom);
            }
        }
        else
        {
            onPhantom = true;
            Phantom();
            onDeath = true;
        }
    }

    public bool onPhantom = false;
    float timePhantom = 3f;
    void Phantom()
    {
        if (!onPhantom)
        {
            onPhantom = !onPhantom;
            sr.color = color;
            Physics2D.IgnoreLayerCollision(11, 12, true);
            return;
        }
        onPhantom = !onPhantom;
        sr.color = Color.white;
        Physics2D.IgnoreLayerCollision(11, 12, false);
    }

    public bool onDeath;
    public bool onDeathAstral = true;
    void Death()
    {
        anim.SetBool("onDeath", onDeath);
        anim.SetBool("onDeathAstral", onDeathAstral);
        if (onDeath && onDeathAstral)
        {
            onDeathAstral = false;
            Invoke("Spawn", 1);
        }
    }

    void Spawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
