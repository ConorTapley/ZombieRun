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
    private bool m_grounded;
    private float m_crawlTimer = 0f;
    public float crawltime = 1f;

    private float m_animationDuration = 2.0f;

    private bool m_isDead = false;
    private float m_startTime;

    public AudioClip jump;
    public AudioClip slide;
    public AudioClip die;
    private AudioSource m_audioSource;


    void Start () {
        m_controller = GetComponent<CharacterController>();
        ainm = GetComponent<Animator>();
        m_charCon = GetComponent<CharacterController>();
        m_startTime = Time.time;
        m_audioSource = GetComponent<AudioSource>();

    }
	

	
	void Update () {

        Debug.Log(crawl);

        if (m_isDead)
            return;

        if(Time.time - m_startTime < m_animationDuration)
        {
            m_controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        m_moveVector = Vector3.zero;

        //if(m_controller.isGrounded)
        if(m_grounded)
        {
            m_verticalVelocity = -0.5f;

            //jump
            if(Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
            {
                ainm.SetBool("Jump", true);
                m_verticalVelocity += jumpPower;
                m_audioSource.PlayOneShot(jump, 1);
                //Debug.Log("Jump");
            }
            else
                ainm.SetBool("Jump", false);


            //Crawl
            if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                crawl = true;
                Crawl();
                m_audioSource.PlayOneShot(slide, 1);
            }
            else
            {
                ainm.SetBool("Crawl", false);
                crawl = false;
            }
            /////crawl timer/////
            /*
            if (crawl)
            {
                m_crawlTimer = crawltime;
                m_crawlTimer -= Time.deltaTime;

                ///when time is up
                if(m_crawlTimer <= 0)
                {
                    crawl = false;
                }
            }
            */

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

    //////////Check if player is grounded/////////////
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tile"))
        {
            m_grounded = true;
            //Debug.Log("Grounded!!");
        }
    }
    //////////check if player is not grounded/////////
    private void OnTriggerExit(Collider other)
    {
        m_grounded = false;
        //Debug.Log("NOT GROUNDED");
    }
    private void OnTriggerEnter(Collider other)
    {
        ///////if the player is not sliding and hits the sword then die////////////
        if(other.CompareTag("Slide") && !crawl)
        {
            Death();
        }
    }


    public void SetSpeed(float modifier)
    {
        speed = 100.0f + modifier;
    }

    
    void Crawl()
    {
        ainm.SetBool("Crawl", true);
    }



    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.CompareTag("Death"))
        {
            Death();
        }

        if(hit.point.z > transform.position.z + m_controller.radius)
        {
            Death();
        }
    }

    private void Death()
    {
        //Debug.Log("Dead");
        m_audioSource.PlayOneShot(die, 1);
        m_isDead = true;

        GetComponent<score>().OnDeath();    
    }

}
