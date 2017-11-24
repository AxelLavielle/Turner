using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            if (collision.gameObject.GetComponent<Plateform>().getColor() == 0)
            {
                transform.parent.gameObject.GetComponent<Body>().Neutral();
            }

            if (collision.gameObject.GetComponent<Plateform>().getColor() == 5)
            {
                transform.parent.gameObject.GetComponent<Body>().Blue();
            }
        }
    }

}
