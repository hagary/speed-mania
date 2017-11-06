using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarHit : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			other.GetComponent <CarController>().soundEffect (Effect.RADAR);
			//Update score
			GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
			GameController gameController = gameControllerObject.GetComponent <GameController> ();
			gameController.SubtractScore (50);
		}
	}
}
