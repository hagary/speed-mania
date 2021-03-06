﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
	public AudioClip jumpClip;
	public AudioClip coinClip;
	public AudioClip obstacleClip;
	public AudioClip radarClip;

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
		rlSpeed = 15f;
	}
		
	// Update is called once per frame
	void Update ()
	{
		carMove ();
		if (Input.GetButtonDown ("Jump"))
			soundEffect (Effect.JUMP);
	}
	void carMove(){
		/*
		 * Horizontal Movement (Input)
		 */
		float moveHorizontal = Input.GetAxis ("Horizontal");
		moveHorizontal = (moveHorizontal + Input.acceleration.x) * rlSpeed * Time.deltaTime;

		/*
		 * Forward Movement (Automatic)
		 */
		float moveForward = fSpeed * Time.deltaTime;

		/*
		 * Jump (Input) 
		 */
		float jump = Input.GetAxis ("Jump");
		jump = jump * jSpeed * Time.deltaTime;

		transform.Translate (moveHorizontal , jump, moveForward);
	}
	public void InstantJump(){
		transform.Translate (0 , jSpeed * Time.deltaTime *10, fSpeed * Time.deltaTime);
		soundEffect (Effect.JUMP);
	}
	public void soundEffect (Effect e)
	{	
		AudioClip clip = null;
		switch (e) {
		case Effect.JUMP:
			clip = jumpClip;
			break;
		case Effect.COIN:
			clip = coinClip;
			break;
		case Effect.OBSTACLE:
			clip = obstacleClip;
			break;
		case Effect.RADAR:
			clip = radarClip;
			break;
		}
		GetComponent <AudioSource> ().PlayOneShot (clip);
	}

	public void IncreaseSpeed ()
	{
		fSpeed += incSpeed;
	}

	public void DecreaseSpeed ()
	{
		fSpeed -= incSpeed;
		fSpeed = fSpeed < originalFSpeed ? originalFSpeed : fSpeed;
	}
}

public enum Effect
{
	JUMP,
	COIN,
	OBSTACLE,
	RADAR
}