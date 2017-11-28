using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamingUI : MonoBehaviour {
    private float timer;
    private int score;
    public Text timerText;
    public Text scoreText;
    public GameObject pauseMenu;

	// Use this for initialization
    void Start () {
        timer = 0f;
        score = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
        TimerText();
        ScoreText();
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

    public void Pause()
    {
        Instantiate(pauseMenu, Vector3.zero, Quaternion.identity);
        Time.timeScale = 0;
    }
}
