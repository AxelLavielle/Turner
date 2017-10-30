using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour {

    public float rotationSpeed;
    SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Light");
        for (int i = 0; i < go.Length; ++i)
            if (go[i].name == "Light")
                renderer = go[i].GetComponent<SpriteRenderer>();
	}

    void setColor(int r, int g, int b)
    {
        renderer.color = new UnityEngine.Color(r, g, b, 0.5f);
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
            setColor(1, 0, 0);
        else if (Input.GetKeyDown("2"))
            setColor(0, 0, 1);
        else if (Input.GetKeyDown("3"))
            setColor(1, 1, 0);
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }

    public int getColor()
    {
        int color = 0;
        if (renderer.color.r > 0)
        {
            color = 1;
            if (renderer.color.g == 1)
                color += 2;
            else if (renderer.color.g > 0)
                color += 1;
            else if (renderer.color.b > 0)
                color += 5;
        }
        else if (renderer.color.g > 0)
            return 4;
        else
            return 5;
        return color;
    }
}
