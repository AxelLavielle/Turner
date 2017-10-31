using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Body {

    private bool facingRight = true;
    private Animator anim;
    private Rigidbody2D rgdbd;
    private bool jump = false;
    private bool grounded = false;
    
    private void Start () {
        anim = GetComponent<Animator>();
        rgdbd = GetComponent<Rigidbody2D>();
    }

    private void Flip()
    {
        //We reverse the boolean
        facingRight = !facingRight;
        //We change the side of looking
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void movements()
    {
        //Get the horizontal axis
        float h = Input.GetAxis("Horizontal");

        //We check if we don't go too fast and speed up if it's ok
        if (h * rgdbd.velocity.x < moveForce * 100)
            rgdbd.velocity = new Vector2((Vector2.right * h * moveForce * 100).x, rgdbd.velocity.y);

        //We look at where our player is running in order to make it face the right direction
        if ((h > 0 && !facingRight) || h < 0 && facingRight)
            Flip();

        //In case the player want to jump, well, we make it jump
        if (grounded && jump && Mathf.RoundToInt(rgdbd.velocity.y / 2) == 0)
        {
            grounded = false;
            rgdbd.AddForce(new Vector2(0f, jumpForce * 100));
        }
        jump = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            jump = true;
    }

    private void FixedUpdate()
    {
        movements();
    }

    private void death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
            grounded = true;
        if (collision.gameObject.CompareTag("Death"))
            death();
    }
}
