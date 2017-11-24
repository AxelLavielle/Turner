using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

    [SerializeField]
    private float moveForceNeutral;
    [SerializeField]
    private float jumpForceNeutral;

    private float gravity;
    private float originalJumpForce;

    protected int direction = -1;

    public bool grounded = false;

    [SerializeField]
    protected float moveForce;
    [SerializeField]
    protected float jumpForce;


    private void Awake()
    {
        moveForce = moveForceNeutral;
        jumpForce = jumpForceNeutral;
        originalJumpForce = jumpForceNeutral;
        gravity = GetComponent<Rigidbody2D>().gravityScale;
    }

    public void Neutral()
    {
        moveForce = moveForceNeutral;
        jumpForce = jumpForceNeutral;
        GetComponent<Rigidbody2D>().gravityScale = gravity;
    }

    public void Red()
    {
        moveForce = moveForceNeutral * 2;
        jumpForce = jumpForceNeutral * 2;
    }

    public void Orange()
    {
        moveForce = moveForceNeutral / 2;
    }

    public void Yellow()
    {

    }

    public void Green()
    {
        if (grounded)
        {
            moveForce = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    public void Blue()
    {
        transform.localPosition = new Vector3(gameObject.transform.localPosition.x, -400, gameObject.transform.localPosition.z);
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public void Purple()
    {
        float temp = transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x;
        if (temp < 0)
            direction = -1;
        else
            direction = 1;
    }


}
