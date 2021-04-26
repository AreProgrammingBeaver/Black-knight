using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Vector3 lastMoveDir;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator anime;
    KeyCode dashKey;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
        Dash();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void Movement()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
            anime.SetBool("GoUp", true);
        }
        else
        {
            anime.SetBool("GoUp", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
            anime.SetBool("GoDown", true);
        }
        else
        {
            anime.SetBool("GoDown", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            anime.SetBool("GoLeft", true);
        }
        else
        {
            anime.SetBool("GoLeft", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
            anime.SetBool("GoRight", true);
        }
        else
        {
            anime.SetBool("GoRight", false);
        }

        bool isIdle = moveX == 0 && moveY == 0;
        if(isIdle)
        {

        }
        else
        {
            
        }

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
       transform.position += moveDir * speed * Time.deltaTime;
       // rb.velocity = new Vector2(moveX, moveY);

        lastMoveDir = moveDir;
    }

    private void Dash()
    {
        float dashdist = 5f;
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position += lastMoveDir * dashdist;
        }
    }
}
