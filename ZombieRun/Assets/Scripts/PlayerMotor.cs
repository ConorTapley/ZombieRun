using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private CharacterController m_controller;
    private Vector3 m_moveVector;

    public float speed;
    private float m_verticalVelocity = 0.0f;
    private float m_gravity = 500f;





    void Start () {
        m_controller = GetComponent<CharacterController>();
	}
	


	
	void Update () {
        m_moveVector = Vector3.zero;


        if(m_controller.isGrounded)
        {
            m_verticalVelocity = -0.5f;
        }
        else
        {
            m_verticalVelocity -= m_gravity * Time.deltaTime;
        }


        //X Left Right
        m_moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        //Y Up Down
        m_moveVector.y = m_verticalVelocity;

        //Z Forward Backward  
        m_moveVector.z = speed;


        m_controller.Move(m_moveVector * Time.deltaTime);
	}
}
