using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {
	public float distTolerance = 10f;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		GameObject car = GameObject.FindGameObjectWithTag ("Player");
		if (car.transform.position.z > transform.position.z + distTolerance)
			Destroy (gameObject);
	}
}
