using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform m_lookAt;
    private Vector3 m_startOffset;
    private Vector3 m_moveVector;

    void Start()
    {
        m_lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        m_startOffset = transform.position - m_lookAt.position;
    }


    void Update()
    {
        m_moveVector = m_lookAt.position + m_startOffset;

        //X
        m_moveVector.x = 0;

        //Y
        m_moveVector.y = Mathf.Clamp(m_moveVector.y, 60, 70);

        transform.position = m_moveVector;
    }
}
