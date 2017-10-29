using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour {

    Player player;

    // Use this for initialization
    void Start () {
        player = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(player.getPosition().x - player.getVelocity().x / 10, player.getPosition().y - player.getVelocity().y / 10, -1);
    }
}
