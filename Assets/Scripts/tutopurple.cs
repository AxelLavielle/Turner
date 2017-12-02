using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutopurple : MonoBehaviour {
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
        if (player.ColorNb() > 1)
        {
            tipsText.text = "You can mix blue and red to obtain the color purple by pressing key 1, 2 then e.\r\nPurple charms enemies and make them go the other way!";
        }

        if (transform.position.x > 1675f)
        {
            tipsText.text = "Bravo! Go to next level!\r\n";
        }

    }
}
