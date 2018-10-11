using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public Animator ainm;

	void Start () {
        ainm = GetComponent<Animator>();
	}
	

	void Update () {
        if (Input.GetKey("space"))
        {
            ainm.SetBool("isWalking", true);
            Debug.Log("walking");
        }
        else
        {
            ainm.SetBool("isWalking", false);
            Debug.Log("idle");
        }
	}
}
