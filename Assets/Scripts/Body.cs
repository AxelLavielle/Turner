using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

    [SerializeField]
    protected float moveForce;
    [SerializeField]
    protected float jumpForce;

    public void Red()
    {
        moveForce *= 2;
        jumpForce *= 2;
    }

    public void Orange()
    {

    }

    public void Yellow()
    {

    }

    public void Green()
    {

    }

    public void Blue()
    {

    }

    public void Purple()
    {

    }
}
