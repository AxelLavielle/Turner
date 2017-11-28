using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3 : MonoBehaviour {
    Player player;
    public GameObject projector;
    GameObject proj;
    GameObject blueLight;
    public Text tipsText;
    bool getBlue;


	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
        getBlue = false;
        tipsText.text = "Go to get the Blue!.";

	}
	
	// Update is called once per frame
	void Update () {
        SetTipsText();
	}

    void CreateBlueLight()
    {
        proj = Instantiate(projector, GameObject.Find("Hand").transform.position, Quaternion.identity);
        proj.transform.parent = this.transform;
        blueLight = GameObject.Find("Light");
        blueLight.GetComponent<SpriteRenderer>().color = new UnityEngine.Color(0, 0, 1, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BluePickup") {
            CreateBlueLight();
            getBlue = true;
            Destroy(collision.gameObject);
        }

    }

    private void SetTipsText()
    {
        if(getBlue) {
            tipsText.text = "You can fly with Blue now. \r\nFly trought the traps. Don't touch!";
        }

        if (transform.position.x > 1675f){
            tipsText.text = "Bravo! Go to next level!\r\nYou can press 2 to use Blue after.";
        }
            
    }


}
