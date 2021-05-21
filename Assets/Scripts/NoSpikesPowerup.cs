using UnityEngine;

public class NoSpikesPowerup : MonoBehaviour {

	private PowerupManager thePM;
    
	void Start () {

		thePM = FindObjectOfType<PowerupManager> ();

	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Player")) {

			thePM.NoSpikesPowerup ();

			gameObject.SetActive (false);

		}

	}

}
