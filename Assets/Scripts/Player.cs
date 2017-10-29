using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private float moveForce;
    [SerializeField]
    private float jumpForce;

    private bool facingRight = true;
    private Animator anim;
    private Rigidbody2D rgdbd;
    private bool jump = false;
    
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
        if (jump && Mathf.RoundToInt(rgdbd.velocity.y / 2) == 0)
            rgdbd.AddForce(new Vector2(0f, jumpForce * 100));
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

}
