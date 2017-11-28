using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Body {
    Rigidbody2D Rigidbody;
    Vector2 oldPosition;
    public bool idle = true;
    float timer;
    bool facingRight;

    public float interval; // Interval shoot time
    public GameObject bullet; // Bullet object

	// Use this for initialization
	void Start () {
        Rigidbody = GetComponent<Rigidbody2D>();
        oldPosition = transform.position;
        timer = 0f;
        facingRight = false;
    }

    private void Flip()
    {
        //We change the side of looking
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        facingRight = !facingRight;
    }

    // Update is called once per frame
    void FixedUpdate () {

        timer += Time.deltaTime;
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

        if (timer > 3f && Vector2.Distance(transform.position, GameObject.Find("Player").transform.position) < 400) // Meet and shoot in a interval time
        {
            Shoot();
        }
        else
            Patrol();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            idle = false;
        }
    }


    // Stop and shoot player when player nearby
    private void Shoot() {


        if (transform.position.x - GameObject.Find("Player").transform.position.x > 0)  // Enemy is on the right side of Player
        {
            if (facingRight) {
                Flip(); // Facing to Player immediately
            }

        }

        GameObject tempBullet = Instantiate(bullet, GameObject.Find("Muzzle").transform.position, Quaternion.identity) as GameObject;
        timer = 0f;

        Vector2 direction = new Vector2(-transform.right.x, 0);
        if (facingRight)
        {
            direction.x = transform.right.x;
        }

        tempBullet.GetComponent<Rigidbody2D>().AddForce(direction * 30000);
        Destroy(tempBullet, 3f);
    }

    // Patrol when enemy didn't see player
    private void Patrol(){
        
    }
}
