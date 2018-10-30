using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;

    public float speed;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        moveVector = Vector3.zero;

        //X Left Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        //Y Up Down

        //Z Forward Backward  
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
	}
}
