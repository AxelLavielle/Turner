using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField]
    Vector2 offset;
    [SerializeField]
    float speed;
    int direction = -1;
    BoxCollider2D box;
    Rigidbody2D Rigidbody;
    Vector2 oldPosition;
    bool idle = true;

	// Use this for initialization
	void Start () {
        box = GetComponent<BoxCollider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        oldPosition = transform.position;
    }

    private void Flip()
    {
        //We change the side of looking
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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
            transform.position = new Vector2(transform.position.x + speed * direction, transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            idle = false;
        }
    }

}
