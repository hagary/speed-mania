using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private bool fpsMode = false;
	bool playing;
	public GameObject FPS;
	public GameObject TPS;
	//	public AudioClip fastClip;
	//	public AudioClip slowClip;
	public AudioSource playSource;
	public AudioSource menuSource;
	// Use this for initialization
	void Start ()
	{
		playing = false;
		fpsMode = false;
		FPS.SetActive (fpsMode);
		TPS.SetActive (!fpsMode);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.C)) {
			switchCamera ();
		}
	}

	public void switchCamera ()
	{
		fpsMode = !fpsMode;
		FPS.SetActive (fpsMode);
		TPS.SetActive (!fpsMode);
	}

	public void switchSound ()
	{
		playing = !playing;
		if (playing) {
			menuSource.Pause ();
			playSource.Play ();

		} else {
			playSource.Pause ();
			menuSource.Play ();
		}
	}
}
