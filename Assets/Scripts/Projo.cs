using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projo : MonoBehaviour {
    Player player;

    // Use this for initialization
    void Start () {
        player = GetComponentInParent<Player>();
	}
	
	// Update is called once per frame
	public void Update () {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.z = 0.0f;
        diff.Normalize();

        if (player.facingRight)
            transform.right = diff;
        else
            transform.right = -diff;
    }
}
