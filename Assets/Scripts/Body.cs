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

    [SerializeField]
    protected float moveForce;
    [SerializeField]
    protected float jumpForce;


    private void Awake()
    {
        originalJumpForce = jumpForce;
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
        moveForce = 0;
    }

    public void Blue()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10000, ForceMode2D.Force);
    }

    public void Purple()
    {
        moveForce = moveForceNeutral / 2;
    }

}
