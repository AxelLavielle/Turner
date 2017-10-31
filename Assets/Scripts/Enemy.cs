using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Transform m_Target;

    public float m_FollowSpeed;

    public float m_FollowRange;

    public float m_ArriveThreshold;
	// Use this for initialization
	void Start () {
        m_Target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Target != null)
        {
            float distance = Vector3.Distance(m_Target.position, transform.position);
            if (distance < m_FollowRange && distance > m_ArriveThreshold)
            {
                transform.Translate((m_Target.position - transform.position) * Time.deltaTime * m_FollowSpeed, Space.World);
            }
        }
	}
}
