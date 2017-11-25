using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Body {
    Rigidbody2D Rigidbody;
    Vector2 oldPosition;
    bool idle = true;
    public GameObject bullet;
    float timer;
    bool isFlip;

	// Use this for initialization
	void Start () {
        Rigidbody = GetComponent<Rigidbody2D>();
        oldPosition = transform.position;
        timer = 0f;
        isFlip = false;
    }

    private void Flip()
    {
        //We change the side of looking
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        isFlip = !isFlip;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (!idle)
        {
            if (Rigidbody.velocity.y < -0.0001)
            {
                Flip();
                direction *= -1;
                transform.position = oldPosition;
            }
            oldPosition = transform.position;
            transform.position = new Vector2(transform.position.x + moveForce * direction, transform.position.y);
        }


        timer += Time.deltaTime;
        Shoot();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            idle = false;
        }
    }

    private void Shoot() {
        if (timer > 4f && Vector2.Distance(transform.position, GameObject.Find("Player").transform.position) < 400)
        {
            GameObject tempBullet = Instantiate(bullet, GameObject.Find("Muzzle").transform.position, Quaternion.identity) as GameObject;
            timer = 0f;
            Vector2 direction = new Vector2(-transform.right.x, 0);
            if(isFlip) {
                direction.x = transform.right.x;
            }              
                
            tempBullet.GetComponent<Rigidbody2D>().AddForce(direction * 30000);
            Destroy(tempBullet, 3f);

        }
    }
}
