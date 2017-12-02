using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {

    SpriteRenderer render;

    Color last1 = Color.red;
    Color last2 = Color.red;

    Renderer rend1;
    Renderer rend2;

    private int colorNumber = 0;
    // Use this for initialization
    void Awake () {
        render = GetComponent<SpriteRenderer>();
        rend1 = GameObject.FindGameObjectWithTag("Last1").GetComponent<Renderer>();
        rend2 = GameObject.FindGameObjectWithTag("Last2").GetComponent<Renderer>();
        if (colorNumber == 0)
            render.color = new UnityEngine.Color(1, 0, 0, 0);
    }

    public void addColor(int i)
    {
        print("adding color");
        colorNumber += i;
        setColor(1, 0, 0);
    }

    public int getColorNb()
    {
        return colorNumber;
    }

    void setColor(float r, float g, float b)
    {
        render.color = new UnityEngine.Color(r, g, b, 0.5f);
    }

	// Update is called once per frame
	void Update () {
       if (Input.GetKeyDown("1") && colorNumber > 0)
        {
            setColor(1, 0, 0);
            last2 = last1;
            last1 = Color.red;
            rend1.material.color = last1;
            rend2.material.color = last2;
        }
        else if (Input.GetKeyDown("2") && colorNumber > 1)
        {
            setColor(0, 0, 1);
            last2 = last1;
            last1 = Color.blue;
            rend1.material.color = last1;
            rend2.material.color = last2;
        }
        else if (Input.GetKeyDown("3") && colorNumber > 2)
        {
            setColor(1, 1, 0);
            last2 = last1;
            last1 = Color.yellow;
            rend1.material.color = last1;
            rend2.material.color = last2;
        }
        else if (Input.GetKeyDown("e") && colorNumber > 1)
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
                r = 1f;
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
        print(render.color.r + " " + render.color.g + " " + render.color.g);
        if (render.color.r > 0.6 && render.color.g > 0.6)
        {
            print("yellow 3");
            return 3;
        }
        if (render.color.r > 0 && render.color.g > 0)
        {
            print("orange 2");
            return 2;
        }
        if (render.color.r > 0 && render.color.b > 0)
        {
            print("purple 6");
            return 6;
        }
        if (render.color.r > 0)
        {
            print("red 1");
            return 1;
        }
        if (render.color.g > 0)
        {
            print("green 4");
            return 4;
        }
        if (render.color.b > 0)
        {
            print("blue 5");
            return 5;
        }
        return 0;
    }
}
