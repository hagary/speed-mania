using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public Transform pauseCanvas;
	public Transform gameOverCanvas;
	public Transform playCanvas;
	public Transform titleCanvas;
	public Text scoreText;

	private bool paused;
	private bool muted;
	private int score;

	// Use this for initialization
	void Start ()
	{	
		/*
		 * Game start setup.
		 */
		Time.timeScale = 0;
		muted = false;
		/*
		 * Score related setup.
		 */
		score = 0;
		UpdateScore ();
		/*
		 * Pause menu related setup.
		 */
		paused = false;
		pauseCanvas.gameObject.SetActive (paused);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}
	}

	void UpdateScore ()
	{	
		scoreText.text = "Score: " + score;
	}

	public void AddScore (int addValue)
	{
		score += addValue;
		if (score % 50 == 0)
			//Increase car speed
			GameObject.FindWithTag ("Player").GetComponent <CarController> ().IncreaseSpeed ();
		UpdateScore ();
	}

	public void SubtractScore (int subValue)
	{
		score -= subValue;
		score = score < 0 ? 0 : score; 
		//Decrease car speed
		GameObject.FindWithTag ("Player").GetComponent <CarController> ().DecreaseSpeed ();
		UpdateScore ();
	}

	public void Pause ()
	{
		paused = !paused;
		pauseCanvas.gameObject.SetActive (paused);
		GameObject.FindWithTag ("CameraController").GetComponent <CameraController>().switchSound ();
		Time.timeScale = paused ? 0 : 1;
	}

	public void Quit ()
	{
		Application.Quit ();
	}

	public void Restart ()
	{
		SceneManager.LoadScene ("Main");
	}

	public void StartGame ()
	{
		titleCanvas.gameObject.SetActive (false);
		playCanvas.gameObject.SetActive (true);
		GameObject.FindWithTag ("CameraController").GetComponent <CameraController>().switchSound ();
		Time.timeScale = 1;
	}

	public void EndGame ()
	{
		gameOverCanvas.gameObject.SetActive (true);
		playCanvas.gameObject.SetActive (false);
		GameObject.FindWithTag ("CameraController").GetComponent <CameraController>().switchSound ();
		Time.timeScale = 0;
	}

	public void Mute ()
	{
		muted = !muted;
		AudioSource audio = GameObject.FindWithTag ("CameraController").GetComponent <AudioSource>();
		audio.mute = muted;
		if (muted) {
			audio.Pause ();
		} else {
			audio.Play ();
		}
	}
}
