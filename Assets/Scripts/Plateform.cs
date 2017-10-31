using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateform : MonoBehaviour {
    [SerializeField]
    private int color;
    private int oldColor;
    [SerializeField]
    private float fadeSpeed = 0.05f;
    SpriteRenderer spriteRenderer;
    Color colorToGo;

    // Use this for initialization
    void Start () {
        colorToGo = new Color(1, 1, 1);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void setColor(int newColor)
    {
        oldColor = color;
        color = newColor;
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

    int getColor()
    {
        return (((color == 0 && spriteRenderer.color.r > 0.9 && spriteRenderer.color.g > 0.9 && spriteRenderer.color.b > 0.9)
            || color != 0) ? color : oldColor);
    }

    // Update is called once per frame
    void FixedUpdate () {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, colorToGo, fadeSpeed);
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (color != -1)
        {
            if (collision.gameObject.tag == "Light")
                setColor(collision.GetComponent<FlashLight>().getColor());
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (color != -1)
        {
            if (collision.gameObject.tag == "Player")
            {
                int tmp = getColor();
                if (tmp == 0)
                    collision.gameObject.GetComponent<Player>().Neutral();
                else if (tmp == 1)
                    collision.gameObject.GetComponent<Player>().Red();
                else if (tmp == 2)
                    collision.gameObject.GetComponent<Player>().Orange();
                else if (tmp == 3)
                    collision.gameObject.GetComponent<Player>().Yellow();
                else if (tmp == 4)
                    collision.gameObject.GetComponent<Player>().Green();
                else if (tmp == 5)
                    collision.gameObject.GetComponent<Player>().Blue();
                else if (tmp == 6)
                    collision.gameObject.GetComponent<Player>().Purple();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (color != -1 && collision.gameObject.tag == "Light")
            setColor(0);
    }
}
