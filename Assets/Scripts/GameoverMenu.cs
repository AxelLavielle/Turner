using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverMenu : MonoBehaviour {
    public Text scoreText;
    public Text timerText;
    GamingUI gamingUI;
	// Use this for initialization
	void Start () {
        gamingUI = new GamingUI();
        gamingUI = GameObject.Find("GamingUI").GetComponent<GamingUI>();
        scoreText.text = gamingUI.scoreText.text;
        timerText.text = gamingUI.timerText.text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Quit(){
        Application.Quit();
    }
}
