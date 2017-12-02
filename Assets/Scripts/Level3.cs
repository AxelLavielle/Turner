using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3 : MonoBehaviour {
    Player player;
    GameObject proj;
    GameObject blueLight;
    public Text tipsText;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>();
        tipsText.text = "Pick up the blue sphere!";

	}
	
	// Update is called once per frame
	void Update () {
        SetTipsText();
	}


    private void SetTipsText()
    {
        if(player.ColorNb() > 1) {
            tipsText.text = "Blue allows you to levitate over the ground\r\nYou can now switch between blue and red with the keys 1 or 2.\r\nFly over the traps. Don't touch them!";
        }

        if (transform.position.x > 1675f){
            tipsText.text = "Bravo! Go to next level!\r\n";
        }
            
    }


}
