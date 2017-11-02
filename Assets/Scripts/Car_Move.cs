using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move : MonoBehaviour {
	public float rlSpeed = 3f;
	public float fSpeed = 3f;
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
		transform.Translate (moveHorizontal, 0, 0);

		/*
		 * Forward Movement (Automatic)
		 */
		float moveForward = rlSpeed * Time.deltaTime;
		transform.Translate (0, 0, moveForward);
	}
}
