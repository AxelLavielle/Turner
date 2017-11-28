using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamingUI : MonoBehaviour {
    private float timer;
    private int score;
    private int life;
    public Text timerText;
    public Text scoreText;
    public Text lifeText;
    public GameObject pauseMenu;
    Player player;

	// Use this for initialization
    void Start () {
        timer = 0f;
        score = 0;
        player = GameObject.Find("Player").GetComponent<Player>();
		
	}
	
	// Update is called once per frame
	void Update () {
        TimerText();
        ScoreText();
        LifeText();
	}

    private void TimerText()
    {
        timer += Time.deltaTime;
        timerText.text = "Time: " + Mathf.Floor(timer).ToString();
    }

    private void ScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private void LifeText()
    {
        life = player.life;
        lifeText.text = "Life: " + life.ToString();
    }

    public void Pause()
    {
        Instantiate(pauseMenu, Vector3.zero, Quaternion.identity);
        Time.timeScale = 0;
    }

    public void setScore() {
        
    }
}
