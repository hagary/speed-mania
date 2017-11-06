using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
	public bool fpsMode = false;
	public GameObject FPS;
	public GameObject TPS;
	// Use this for initialization
	void Start ()
	{
		FPS.SetActive (fpsMode);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("escape")) {
			fpsMode = !fpsMode;
			FPS.SetActive (fpsMode);
			TPS.SetActive (!fpsMode);
		}
	}
}
