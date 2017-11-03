using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move : MonoBehaviour {
	public float rlSpeed = 3f;
	public float fSpeed = 5f;
	public float jSpeed = 4f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*
		 * Horizontal Movement (Input)
		 */
		float moveHorizontal = Input.GetAxis ("Horizontal");
		moveHorizontal = moveHorizontal * rlSpeed * Time.deltaTime;

		/*
		 * Forward Movement (Automatic)
		 */
		float moveForward = rlSpeed * Time.deltaTime;

		/*
		 * Jump (Input) 
		 */
		float jump = Input.GetAxis ("Jump");
		jump = jump * jSpeed * Time.deltaTime;

		transform.Translate (moveHorizontal, jump, moveForward + jump/2);
	}
}
