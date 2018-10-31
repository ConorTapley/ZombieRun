using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private Animator ainm;
    private CharacterController m_controller;
    private Vector3 m_moveVector;
    private Transform m_transform;
    private CharacterController m_charCon;
    private bool crawl = false;

    public float speed;
    public float jumpPower;
    private float m_verticalVelocity;
    public float gravity;

    private float m_animationDuration = 2.0f;


    void Start () {
        m_controller = GetComponent<CharacterController>();
        ainm = GetComponent<Animator>();
        m_charCon = GetComponent<CharacterController>();
	}
	

	
	void Update () {

        if(Time.time < m_animationDuration)
        {
            m_controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        m_moveVector = Vector3.zero;

        if(m_controller.isGrounded)
        {
            m_verticalVelocity = -0.5f;

            //jump
            if(Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
            {
                ainm.SetBool("Jump", true);
                m_verticalVelocity += jumpPower;
                Debug.Log("Jump");
            }
            else
                ainm.SetBool("Jump", false);


            //Crawl
            if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Crawl();
            }
            else
            {
                ainm.SetBool("Crawl", false);
                crawl = false;
            }

            if (crawl)
            {
                m_charCon.height -= 20;
            }
            else m_charCon.height = 120;


        }
        else
        {
            m_verticalVelocity -= gravity * Time.deltaTime;
            ainm.SetBool("Jump", false);
        }


        //X Left Right
        m_moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        //Y Up Down
        m_moveVector.y = m_verticalVelocity;

        //Z Forward Backward  
        m_moveVector.z = speed;


        m_controller.Move(m_moveVector * Time.deltaTime);
	}

    public void SetSpeed(float modifier)
    {
        speed = 100.0f + modifier;
    }



    void Crawl()
    {
        ainm.SetBool("Crawl", true);
        Debug.Log("Crawl");

        m_charCon.height -= 100;

        crawl = true;
    }
}
