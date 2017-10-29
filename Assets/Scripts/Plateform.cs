using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateform : MonoBehaviour {
    [SerializeField]
    private int color;
    [SerializeField]
    private float fadeSpeed = 0.05f;
    SpriteRenderer spriteRenderer;
    Color colorToGo;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void setColor()
    {
        if (color == 0) //Neutral
            colorToGo = new Color(1, 1, 1);
        else if (color == 1) //Red
            colorToGo = new Color(1, 0, 0);
        else if (color == 2) //Orange
            colorToGo = new Color(1, 0.5f, 0);
        else if (color == 3) //Yellow
            colorToGo = new Color(1, 1, 0);
        else if (color == 4) //Green
            colorToGo = new Color(0, 1, 0);
        else if (color == 5) //Blue
            colorToGo = new Color(0, 0, 1);
        else if (color == 6) //Purple
            colorToGo = new Color(1, 0, 1);
    }

    // Update is called once per frame
    void FixedUpdate () {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, colorToGo, fadeSpeed);
        setColor();
	}

}
