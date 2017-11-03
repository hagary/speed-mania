using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
	public float translateZ = 50f;
	public GameObject road;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			//Move road forward in z-direction to create infinite road illusion.
			road.transform.Translate(0, 0, translateZ * Time.deltaTime);
		}
	}
}
