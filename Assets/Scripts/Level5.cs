using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level5 : MonoBehaviour {
    Player player;
    GameObject proj;
    GameObject blueLight;
    public Text tipsText;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Player>();
        tipsText.text = "Pick up the yellow sphere!";

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
            tipsText.text = "Yellow allows you to activate moving plateforms\r\nYellow can be activated with the key 3\r\nCross the level while activating the plateforms!";
        }

        if (transform.position.x > 1675f)
        {
            tipsText.text = "Bravo! Go to next level!\r\n";
        }

    }

}
