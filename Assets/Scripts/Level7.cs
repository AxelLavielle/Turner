using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level7 : MonoBehaviour {
    Player player;
    GameObject proj;
    GameObject blueLight;
    public Text tipsText;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTipsText();
    }


    private void SetTipsText()
    {
        if (player.ColorNb() > 2)
        {
            tipsText.text = "You can mix blue and yellow to obtain the color green by pressing key 2, 3 then e.\r\nGreen allows you to stick to walls and jump on them!";
        }

        if (transform.position.x > 1675f)
        {
            tipsText.text = "Bravo! Go to next level!\r\n";
        }

    }

}
