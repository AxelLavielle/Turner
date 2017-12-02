using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour
{
    Player player;
    GameObject proj;
    GameObject redLight;
    public Text tipsText;
    bool getRed;


    // Use this for initialization
    void Start()
    {
        player = GetComponent<Player>();
        getRed = false;
        tipsText.text = "Pick up the red color!";
    }

    // Update is called once per frame
    void Update()
    {
        SetTipsText();
    }

    private void SetTipsText()
    {
        if (player.ColorNb() > 0)
        {
            tipsText.text = "Point the light at the ground to speed up and jump higher. \r\nGo to the destination";
        }

        if (transform.position.x > 2600f)
        {
            tipsText.text = "Bravo! Go to next level!";
        }

    }


}
