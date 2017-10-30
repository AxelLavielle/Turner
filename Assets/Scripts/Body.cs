using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

    [SerializeField]
    private float moveForceNeutral;
    [SerializeField]
    private float jumpForceNeutral;

    [SerializeField]
    protected float moveForce;
    [SerializeField]
    protected float jumpForce;

    public void Neutral()
    {
        moveForce = moveForceNeutral;
        jumpForce = jumpForceNeutral;
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
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForceNeutral, ForceMode2D.Force);
    }

    public void Purple()
    {
        moveForce = moveForceNeutral / 2;
    }

}
