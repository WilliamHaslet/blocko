using UnityEngine;

public class SideHit : MonoBehaviour {

	private PlayerController thePC;

    private ScoreManager scoreManager;
    
    void Start () {

		thePC = FindObjectOfType<PlayerController> ();

        scoreManager = FindObjectOfType<ScoreManager>();

    }

	void OnCollisionEnter2D (Collision2D other) {
        
		if (other.gameObject.CompareTag ("Player")) {
            
			thePC.canDoubleJump = false;

            thePC.hasJumped = true;

            thePC.canInfiniteJump = false;

			thePC.grounded = false;

            if (scoreManager.highScoreKey == "Gravity2Highscore" || scoreManager.highScoreKey == "FlightHighscore")
            {
                thePC.cancelJump = true;
               
            }

		}

	}

}
