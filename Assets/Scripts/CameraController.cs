using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private bool fpsMode = false;
	bool playing;
	public GameObject FPS;
	public GameObject TPS;
	public AudioClip fastClip;
	public AudioClip slowClip;

	private AudioSource audioSource;
	// Use this for initialization
	void Start ()
	{
		playing = false;
		fpsMode = false;
		FPS.SetActive (fpsMode);
		audioSource = GetComponent <AudioSource> ();
		audioSource.playOnAwake = true;
		audioSource.clip = slowClip;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.C)) {
			fpsMode = !fpsMode;
			FPS.SetActive (fpsMode);
			TPS.SetActive (!fpsMode);
		}
	}

	public void switchSound(){
		playing = !playing;
		audioSource.Stop ();
		if (playing)
			audioSource.clip = fastClip;
		else
			audioSource.clip = slowClip;
		audioSource.Play ();
	}
}
