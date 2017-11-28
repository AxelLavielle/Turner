using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {

    SpriteRenderer render;

    Color last1 = Color.red;
    Color last2 = Color.red;

    Renderer rend1;
    Renderer rend2;

    // Use this for initialization
    void Start () {
        render = GetComponent<SpriteRenderer>();
        rend1 = GameObject.FindGameObjectWithTag("Last1").GetComponent<Renderer>();
        rend2 = GameObject.FindGameObjectWithTag("Last2").GetComponent<Renderer>();
        setColor(1, 0, 0);
    }

    void setColor(float r, float g, float b)
    {
        render.color = new UnityEngine.Color(r, g, b, 0.5f);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
        {
            setColor(1, 0, 0);
            last2 = last1;
            last1 = Color.red;
            rend1.material.color = last1;
            rend2.material.color = last2;
        }
        else if (Input.GetKeyDown("2"))
        {
            setColor(0, 0, 1);
            last2 = last1;
            last1 = Color.blue;
            rend1.material.color = last1;
            rend2.material.color = last2;
        }
        else if (Input.GetKeyDown("3"))
        {
            setColor(1, 1, 0);
            last2 = last1;
            last1 = Color.yellow;
            rend1.material.color = last1;
            rend2.material.color = last2;
        }
        else if (Input.GetKeyDown("e"))
            Mix();
    }

    private void Mix()
    {
        float r = 0;
        float g = 0;
        float b = 0;
        if (last1 == Color.red)
            r = 1;
        else if (last1 == Color.blue)
            b = 1;

        if (last2 == Color.red)
            r = 1;
        else if (last2 == Color.blue)
            b = 1;

        if(last1 == Color.yellow)
        {
            if (last2 == Color.red)
            {
                r = 0.5f;
                g = 0.5f;
            }
            else if (last2 == Color.blue)
            {
                b = 0;
                g = 1;
            }
            else
            {
                r = 1;
                g = 1;
            }
        }
        if (last2 == Color.yellow)
        {
            if (last1 == Color.red)
            {
                r = 0.5f;
                g = 0.5f;
            }
            else if (last1 == Color.blue)
                g = 1;
        }
        setColor(r, g, b);
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
