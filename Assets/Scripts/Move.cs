﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    [SerializeField]
    Vector3 moveTo;
    [SerializeField]
    float speed;
    Vector3 start;

	// Use this for initialization
	void Start () {
        start = transform.position;
	}

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveTo, Time.deltaTime * speed);
        if (transform.position.x == moveTo.x && transform.position.y == moveTo.y)
        {
            moveTo = start;
            start = transform.position;
        }
    }
}
