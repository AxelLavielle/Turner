using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projo : MonoBehaviour {
    Player player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x != player.transform.localScale.x)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= player.transform.localScale.x;
            transform.localScale = newScale;
        }
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
}
