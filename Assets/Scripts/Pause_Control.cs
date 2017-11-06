using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Control : MonoBehaviour
{
	public Transform pauseCanvas;
	bool paused;
	// Use this for initialization
	void Start ()
	{
		paused = false;	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}
	}

	public void Pause ()
	{
		paused = !paused;
		pauseCanvas.gameObject.SetActive (paused);
		Time.timeScale = paused ? 0 : 1;
	}
}
