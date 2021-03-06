using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level4 : MonoBehaviour {
    Player player;
    public GameObject projector;
    GameObject proj;
    GameObject blueLight;
    public GameObject tips;
    public Text tipsText;
    bool win;


	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
        win = false;
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
            Destroy(collision.gameObject);
        }

    }

    private void SetTipsText()
    {
        if (transform.position.x > 8000f && !win){
            Instantiate(tips, Vector2.zero, Quaternion.identity);
            win = true;
        }
        tipsText.text = "Bravo! Go to next level!";
            
    }


}
