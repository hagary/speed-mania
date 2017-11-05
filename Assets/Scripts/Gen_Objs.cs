using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen_Objs : MonoBehaviour
{
	public GameObject coinPrefab;
	public GameObject obstaclePrefab;
	public GameObject radarPrefab;
	public Transform road;
	float lastCarPosition;
	float distToObstacle;
	float distToRepeat;

	// Use this for initialization
	void Start ()
	{
		lastCarPosition = Mathf.NegativeInfinity;
		distToObstacle = 50;
		distToRepeat = 50;
	}

	// Update is called once per frame
	void Update ()
	{
		float currCarPosition = transform.position.z;
		if (currCarPosition < lastCarPosition + distToRepeat)
			return;
		
		int objectType = Random.Range (1, 4);
		int laneNumber = Random.Range (-1, 2);
		GameObject prefabToInst = null;
		print ("Object num: " + objectType);
		print ("Lane num: " + laneNumber);
		/*
		 * Choose a random object to instantiate.
		 */
		switch (objectType) {
		case 1:
			prefabToInst = coinPrefab;
			break;
		case 2:
			prefabToInst = obstaclePrefab;
			break;
		case 3:
			prefabToInst = radarPrefab;
			laneNumber = 0; //middle lane
			break;
		}
		Instantiate (prefabToInst, new Vector3 (laneNumber*10f, 0, currCarPosition + distToObstacle), prefabToInst.transform.rotation);
		lastCarPosition = currCarPosition;
	}
}
