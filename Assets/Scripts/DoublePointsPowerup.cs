using UnityEngine;

public class DoublePointsPowerup : MonoBehaviour {

	private PowerupManager thePM;
    
	void Start () {

		thePM = FindObjectOfType<PowerupManager> ();
		
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.CompareTag ("Player")) {

			thePM.DoublePointsPowerup ();

			gameObject.SetActive (false);

		}
	
	}

}
