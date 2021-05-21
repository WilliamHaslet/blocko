using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

	public int scoreToGive;

	public int coinsToGive;

	private ScoreManager theScoreManager;

	private AudioSource coinSound;

	// Use this for initialization
	void Start () {

		theScoreManager = FindObjectOfType<ScoreManager> ();

		coinSound = GameObject.Find ("Audio").GetComponent<AudioSource> ();
		
	}

	private void Update()
	{

		if (Input.GetKeyDown(KeyCode.C))
		{

			theScoreManager.AddScore(0, 1000);

		}

	}

	void OnTriggerEnter2D (Collider2D other) {
	
		if (other.CompareTag ("Player")) {
		
			theScoreManager.AddScore (scoreToGive, coinsToGive);

            gameObject.SetActive(false);

            if (coinSound.isPlaying) {

				coinSound.Stop ();

				coinSound.Play ();

			} else {

				coinSound.Play ();
		
			}
            
        }
	
	}
		
}
