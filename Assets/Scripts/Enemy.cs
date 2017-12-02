using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Body {
    Rigidbody2D Rigidbody;
    Animator anim;

	// Use this for initialization
	void Start () {
        Rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Flip()
    {
        //We change the side of looking
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        direction *= -1;
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate(new Vector2(direction, 0) * moveForce * Time.deltaTime);

        Debug.Log("Enemy.vel.x: " + Rigidbody.velocity.x);
        if (Mathf.Abs(Rigidbody.velocity.x) > 0)
            anim.SetBool("isWalking", true);
        if (Mathf.Approximately(Rigidbody.velocity.x, 0))
            anim.SetBool("isWalking", false);
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor_End")
        {
            Flip();
        }
        else if (collision.gameObject.tag == "Death" || collision.gameObject.tag == "Trap")
            Destroy(gameObject);
    }

}
