using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userConrol : MonoBehaviour {

    private float m_turn;
    private float m_forward;
    private bool m_jump;

    private Character m_character;

	// Use this for initialization
	private void Start () {
        m_character = GetComponent<Character>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Get Inputs
        m_turn = Input.GetAxis("Horizontal");
        m_forward = Input.GetAxis("Vertical");
        m_jump = Input.GetButtonDown("Jump");

        m_character.Move(m_turn, m_forward, m_jump);
	}
}
