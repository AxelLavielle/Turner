using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGun : MonoBehaviour {
    public static ColorGun Instance;
    public float m_bulletSpeed; // Bullet Speed;
    public bool m_shot; // Ready to shoot or not

    private Transform gun; // Gun body
    private Transform muzzle; // Shoot position for the bullet


	// Use this for initialization
	void Start () {
        Instance = this;
        gun = this.transform;
        muzzle = gun.Find("Muzzle");

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 tarPos = Input.mousePosition;
        Vector3 objPos = Camera.main.WorldToScreenPoint((transform.position));
        Vector3 direction = tarPos - objPos;
        direction.z = 0f;
        direction = direction.normalized;
        transform.right = direction;
		
	}
}
