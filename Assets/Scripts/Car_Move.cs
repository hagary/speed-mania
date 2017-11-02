using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Move : MonoBehaviour {
	public float rlSpeed = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		moveHorizontal = moveHorizontal * rlSpeed * Time.deltaTime;
		transform.Translate (moveHorizontal, 0, 0);
	}
}
