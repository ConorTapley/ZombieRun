using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour {

    private Transform playerT;
    private float m_rotationSpeed = 8f;
    private float m_moveSpeed = 20f;
    private float m_distance;

    private void Start()
    {
        playerT = GameObject.Find("Player").transform;
    }

    void Update ()
    {
        //////////////Rotate towards player//////////////////
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerT.position - transform.position), 
                                                m_rotationSpeed * Time.deltaTime);

        /////////////Check the distance from the player/////////////
        m_distance = Vector3.Distance(transform.position, playerT.position);
        //Debug.Log(m_distance);

        /////////////Move towards player////////////////
        if(m_distance <= 200)
        {
            transform.position += transform.forward * m_moveSpeed * Time.deltaTime;
        }
	}
}
