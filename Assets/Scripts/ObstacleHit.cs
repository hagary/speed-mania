using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter (Collision other)
	{
		if (other.collider.tag == "Player") {
			other.collider.GetComponent <CarController>().soundEffect (Effect.OBSTACLE);
			GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
			GameController gameController = gameControllerObject.GetComponent <GameController> ();
			gameController.EndGame ();
		}
	}
}
