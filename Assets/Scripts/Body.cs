using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

    [SerializeField]
    private float moveForceNeutral;
    [SerializeField]
    private float jumpForceNeutral;

    private float gravity;

    public int direction = -1;

    public bool grounded = false;

    [SerializeField]
    protected float moveForce;
    [SerializeField]
    protected float jumpForce;


    private void Awake()
    {
        moveForce = moveForceNeutral;
        jumpForce = jumpForceNeutral;
        gravity = GetComponent<Rigidbody2D>().gravityScale;
    }

    public void reset()
    {
        grounded = true;
        Neutral();
    }

    public void Neutral()
    {
        moveForce = moveForceNeutral;
        jumpForce = jumpForceNeutral;
        GetComponent<Rigidbody2D>().gravityScale = gravity;
    }

    public void Red()
    {
        moveForce = moveForceNeutral * 1.5f;
        jumpForce = jumpForceNeutral * 1.5f;
    }

    public void Orange()
    {
        moveForce = moveForceNeutral / 2;
    }

    public void Green()
    {
        moveForce = 0;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public void Blue(float dist)
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * ((150 - dist) * 30));
    }

    public void Purple()
    {
        float temp = transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x;
        Enemy enemy = GetComponent<Enemy>();
        if (enemy != null)
        {
            if (temp < 0 && direction == 1)
            {
                enemy.Flip();
            }
            else if (temp > 0 && direction == -1)
            {
                enemy.Flip();
            }
        }
    }


}
