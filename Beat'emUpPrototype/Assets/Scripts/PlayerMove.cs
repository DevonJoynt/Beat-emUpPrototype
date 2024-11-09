using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]private float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private bool grounding;

    //float horizontal;
    //float vertical;

    private void Awake()
    {
        //references for rb and animator from object
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

       // horizontal = Input.GetAxis("Horizontal");
       // vertical = Input.GetAxis("vertical");

        //flip the player when moving left to right
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        
        
        

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && grounding)
            Jump();

        //set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounding", grounding);

        
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed);
        anim.SetTrigger("jump");
        grounding = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Ground")
            grounding = true;
            
    }
}
