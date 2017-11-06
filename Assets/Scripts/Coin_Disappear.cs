using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Disappear : MonoBehaviour
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
			//Update score
			GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
			GameController gameController = gameControllerObject.GetComponent <GameController> ();
			gameController.AddScore (10);

			Destroy (gameObject);
		}
	}
}
