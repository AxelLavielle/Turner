using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {

    SpriteRenderer render;

	// Use this for initialization
	void Start () {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Light");
        for (int i = 0; i < go.Length; ++i)
            if (go[i].name == "Light")
                render = go[i].GetComponent<SpriteRenderer>();
	}

    void setColor(int r, int g, int b)
    {
        render.color = new UnityEngine.Color(r, g, b, 0.5f);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
            setColor(1, 0, 0);
        else if (Input.GetKeyDown("2"))
            setColor(0, 0, 1);
        else if (Input.GetKeyDown("3"))
            setColor(1, 1, 0);
    }

    public int getColor()
    {
        int color = 0;
        if (render.color.r > 0)
        {
            color = 1;
            if (render.color.g == 1)
                color += 2;
            else if (render.color.g > 0)
                color += 1;
            else if (render.color.b > 0)
                color += 5;
        }
        else if (render.color.g > 0)
            return 4;
        else
            return 5;
        return color;
    }
}
