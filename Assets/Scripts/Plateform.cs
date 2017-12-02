using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateform : MonoBehaviour {
    [SerializeField]
    private int color;
    private int oldColor;

    [SerializeField]
    bool isActivable = false;
    [SerializeField]
    Vector2 moveTo;
    [SerializeField]
    bool doGoBack = true;
    [SerializeField]
    float speed = 1;

    Vector2 startPoint;

    [SerializeField]
    private float fadeSpeed = 0.05f;
    SpriteRenderer spriteRenderer;
    Color colorToGo;

    // Use this for initialization
    void Start () {
        colorToGo = new Color(1, 1, 1);
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPoint = transform.position;
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

    public int getColor()
    {
        return (((color == 0 && spriteRenderer.color.r > 0.9 && spriteRenderer.color.g > 0.9 && spriteRenderer.color.b > 0.9)
            || color != 0) ? color : oldColor);
    }

    // Update is called once per frame
    void FixedUpdate () {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, colorToGo, fadeSpeed);
        if (color == 3 && isActivable)
            Move();
	}

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveTo, Time.deltaTime * speed);
        if (transform.position.x == moveTo.x && transform.position.y == moveTo.y)
        {
            if (doGoBack)
            {
                moveTo = startPoint;
                startPoint = transform.position;
            }
            else
                isActivable = false;
        }
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
            Body tmpBody = collision.gameObject.GetComponent<Body>();
            if (tmpBody != null)
            {
                int tmp = getColor();
                tmpBody.Neutral();
                if (tmp == 1)
                    tmpBody.Red();
                else if (tmp == 2)
                    tmpBody.Orange();
                else if (tmp == 4)
                    tmpBody.Green();
                else if (tmp == 6)
                    tmpBody.Purple();
            }
        }
        if (isActivable == true && collision.gameObject.tag == "Player" && color == 3 && (transform.position.y - moveTo.y < 0))
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 80, ForceMode2D.Impulse);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("OnTriggerExit2D");
        if (color != -1 && collision.gameObject.tag == "Light")
        {
            setColor(0);
        }
    }



}
