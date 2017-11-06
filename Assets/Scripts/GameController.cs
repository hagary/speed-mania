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
	public Transform howMenu;
	public Transform creditsMenu;
	public Text scoreText;

	private bool paused;
	private bool playing;
	private bool muted;
	private bool showHow;
	private bool showCredits;
	private int score;

	// Use this for initialization
	void Start ()
	{	
		/*
		 * Game start setup.
		 */
		titleCanvas.gameObject.SetActive (true);
		playCanvas.gameObject.SetActive (false);
		Time.timeScale = 0;
		muted = false;
		showHow = false;
		showCredits = false;
		howMenu.gameObject.SetActive (showHow);
		creditsMenu.gameObject.SetActive (showCredits);
		/*
		 * Score related setup.
		 */
		score = 0;
		UpdateScore ();
		/*
		 * Pause menu related setup.
		 */
		paused = false;
		playing = false;
		pauseCanvas.gameObject.SetActive (paused);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playing && Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}
	}

	void UpdateScore ()
	{	
		scoreText.text = "SCORE: " + score;
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
		GameObject.FindWithTag ("CameraController").GetComponent <CameraController> ().switchSound ();
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
		GameObject.FindWithTag ("CameraController").GetComponent <CameraController> ().switchSound ();
		Time.timeScale = 1;
		playing = true;
	}

	public void EndGame ()
	{
		gameOverCanvas.gameObject.SetActive (true);
		playCanvas.gameObject.SetActive (false);
		GameObject.FindWithTag ("CameraController").GetComponent <CameraController> ().switchSound ();
		Time.timeScale = 0;
		playing = false;
	}

	public void Mute ()
	{
		muted = !muted;
		AudioSource[] audios = GameObject.FindWithTag ("CameraController").GetComponents <AudioSource> ();
		audios [0].mute = muted;
		audios [1].mute = muted;
		if (muted) {
			audios [0].Stop ();
			audios [1].Stop ();
		} else {
			audios [0].Play ();
		}
	}

	public void ShowHow ()
	{
		showHow = !showHow;
		howMenu.gameObject.SetActive (showHow);
	}

	public void ShowCredits ()
	{
		showCredits = !showCredits;
		creditsMenu.gameObject.SetActive (showCredits);
	}
}
