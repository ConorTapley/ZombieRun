using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    
    private bool m_movingRight = true;
    private bool m_moveingLeft = false;
    private Vector3 tempPos;

    private Rigidbody myRb;
    public LayerMask enemyMask;

    public float moveSpeed = 0.2f;

    private void Start()
    {
        myRb = GetComponent<Rigidbody>();
        tempPos = transform.position;
    }

    private void Update()
    {
        tempPos.z -= moveSpeed;
        tempPos.x += moveSpeed;    
        transform.position = tempPos;
        /*
        if(m_movingRight && !m_moveingLeft)
        {
            tempPos.x--;
            transform.position = tempPos;
        }
        if(m_moveingLeft && !m_movingRight)
        {
            tempPos.x++;
            transform.position = tempPos;
        }
        */
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            Debug.Log("wall");
        }

        if(other.CompareTag("Wall") && m_movingRight)
        {
            m_movingRight = false;
            m_moveingLeft = true;
            Debug.Log("wall");
        }
        if(other.CompareTag("Wall") && m_moveingLeft)
        {
            m_moveingLeft = false;
            m_movingRight = true;
            Debug.Log("wall");  
        }
    }


    void MoveRight()
    {
       
    }


    void MoveLeft()
    {

    }
}
