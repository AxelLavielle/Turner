using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamingUI : MonoBehaviour {
    private float timer;
    public Text timerText;
    public GameObject pauseMenu;

	// Use this for initialization
    void Start () {
        timer = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {
        TimerText();
	}

    private void TimerText()
    {
        timer += Time.deltaTime;
        timerText.text = "Time: " + Mathf.Floor(timer).ToString();
    }

    public void Pause()
    {
        Instantiate(pauseMenu, Vector3.zero, Quaternion.identity);
        Time.timeScale = 0;
    }
}
