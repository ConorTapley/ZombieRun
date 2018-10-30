using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform m_lookAt;
    private Vector3 m_startOffset;
    private Vector3 m_moveVector;

    private float m_transition = 0.0f;
    private float m_animationDuration = 2.0f;
    private Vector3 m_animationOffSet = new Vector3(0, 60, 70);

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

        if(m_transition > 1.0f)
        {
            transform.position = m_moveVector;
        }
        else
        {
            //Start Animation
            transform.position = Vector3.Lerp(m_moveVector + m_animationOffSet, m_moveVector, m_transition);
            m_transition += Time.deltaTime * 1 / m_animationDuration;
        }
        
    }
}
