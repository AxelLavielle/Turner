using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Continue()
    {
        Destroy(GameObject.FindWithTag("PauseMenu"));
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
