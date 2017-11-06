using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public Transform pauseCanvas;
	bool paused;

	public Text scoreText;
	private int score;
	// Use this for initialization
	void Start ()
	{	
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
		if (score > 0 && score % 50 == 0)
			//Increase car speed
			GameObject.FindWithTag ("Player").GetComponent <CarController> ().IncreaseSpeed ();
		scoreText.text = "Score: " + score;
	}

	public void AddScore (int addValue)
	{
		score += addValue;
		UpdateScore ();
	}

	public void Pause ()
	{
		paused = !paused;
		pauseCanvas.gameObject.SetActive (paused);
		Time.timeScale = paused ? 0 : 1;
	}

	public void Quit ()
	{
		Application.Quit ();
	}

	public void Restart ()
	{
		SceneManager.LoadScene ("Main");
		Time.timeScale = 1;
	}
}
