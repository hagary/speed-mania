using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
	private float originalFSpeed;
	private float rlSpeed;
	private float fSpeed;
	private float jSpeed;
	private float incSpeed;
	// Use this for initialization
	void Start ()
	{
		incSpeed = 5;
		jSpeed = 15f;
		originalFSpeed = fSpeed = 10f;
		rlSpeed = 10f;
	}
		
	// Update is called once per frame
	void Update ()
	{
		/*
		 * Horizontal Movement (Input)
		 */
		float moveHorizontal = Input.GetAxis ("Horizontal");
		moveHorizontal = moveHorizontal * rlSpeed * Time.deltaTime;

		/*
		 * Forward Movement (Automatic)
		 */
		float moveForward = fSpeed * Time.deltaTime;

		/*
		 * Jump (Input) 
		 */
		float jump = Input.GetAxis ("Jump");
		jump = jump * jSpeed * Time.deltaTime;

		transform.Translate (moveHorizontal, jump, moveForward + jump);
	}

	public void IncreaseSpeed(){
		fSpeed += incSpeed;
		print ("Speed increased: " + fSpeed);
	}
	public void DecreaseSpeed(){
		fSpeed -= incSpeed;
		fSpeed = fSpeed < originalFSpeed ? originalFSpeed : fSpeed;
		print ("Speed decreased: " + fSpeed);
	}
}
