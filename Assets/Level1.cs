using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour
{
    Player player;
    public GameObject projector;
    GameObject proj;
    GameObject redLight;
    public Text tipsText;
    bool getRed;


    // Use this for initialization
    void Start()
    {
        player = GetComponent<Player>();
        getRed = false;
        tipsText.text = "Go to get the Red!";

    }

    // Update is called once per frame
    void Update()
    {
        SetTipsText();
    }

    void CreateBlueLight()
    {
        proj = Instantiate(projector, GameObject.Find("Hand").transform.position, Quaternion.identity);
        proj.transform.parent = this.transform;
        redLight = GameObject.Find("Light");
        redLight.GetComponent<SpriteRenderer>().color = new UnityEngine.Color(1, 0, 0, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BluePickup")
        {
            CreateBlueLight();
            getRed = true;
            Destroy(collision.gameObject);
        }

    }

    private void SetTipsText()
    {
        if (getRed)
        {
            tipsText.text = "You can boost yourself with Red now. \r\nGo to the destination";
        }

        if (transform.position.x > 2600f)
        {
            tipsText.text = "Bravo! Go to next level!\r\nYou can press 1 to use Red after.";
        }

    }


}
