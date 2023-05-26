using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaScripts : Monster
{
    public enum State { Idle, Left, Right, Die}

    //private bool isDie = false;

    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] LayerMask GoombaMask;
    private GameObject player;


    private Rigidbody2D rb;
    private Animator anim;
    private CapsuleCollider2D capCollider;
    private CircleCollider2D circleCollider;
    public State curState;
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        capCollider = GetComponent<CapsuleCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        curState = State.Left;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (curState == State.Left)
        {
            rb.velocity = new Vector2(transform.right.x * -1 * moveSpeed, rb.velocity.y);
        }
        else if (curState == State.Right)
        {
            rb.velocity = new Vector2(transform.right.x * moveSpeed, rb.velocity.y);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger ON");
        
        if(other.gameObject.name == "Fire")
        {
            anim.SetBool("HitFire", true);
            Die();
        }
        else if(other.gameObject.tag == "Object")
        {
            if(curState == State.Left) {
                Debug.Log("Left call");
                curState = State.Right;
            }
            else if (curState == State.Right) {
                Debug.Log("Right call");
                curState = State.Left;
            }
        }else if(other.gameObject.tag == "Player")
        {
            if(player.transform.position.y - transform.position.y > 1f)
            {
                anim.SetBool("MonsterDie", true);
                Debug.Log("±À¹Ù Á×À½");
                Die();
            }
            else
            {
                Debug.Log("ÇÃ·¹ÀÌ¾î Á×À½");
            }
        }
        
    }
    private void Die()
    {
        rb.gravityScale = 1.0f;
        rb.velocity = Vector2.up * 3;
        capCollider.enabled = false;
        circleCollider.enabled = false;
    }
}
