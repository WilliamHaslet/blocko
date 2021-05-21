using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameplayManager : MonoBehaviour {

	public Transform platformGenerator;

	private Vector3 platformStartPoint;

	public PlayerController thePlayer;

	private Vector3 playerStartPoint;

	private ObjectDestroyer[] platformList;

	public ScoreManager scoreManager;

	public PowerupManager powerupManager;

	public GameObject pauseButton;

	public bool powerupReset;

    public GameObject loseMenu;

    public TextMeshProUGUI loseText;

    // Use this for initialization
    void Start () {

		platformStartPoint = platformGenerator.position;

		playerStartPoint = thePlayer.transform.position;

		powerupReset = false;

	}

	public void EndGame () {

		scoreManager.scoreIncreasing = false;

        if (powerupManager.activatePointsPowerup)
        {

            powerupManager.pointsPowerupLengthCounter = 0f;

        }

        if (powerupManager.activateSpikesPowerup)
        {

            powerupManager.spikesPowerupLengthCounter = 0f;

        }

        thePlayer.gameObject.SetActive (false);

        pauseButton.SetActive (false);

        float randomNumber = Random.Range(0f, 100f);

        if (randomNumber < 20)
        {

            loseText.text = "Better Luck Next Time!";

        }
        else if (randomNumber < 40 && randomNumber >= 20)
        {

            loseText.text = "Practice Makes Perfect!";

        }
        else if (randomNumber < 60 && randomNumber >= 40)
        {

            loseText.text = "Try Again!";

        }
        else if (randomNumber < 80 && randomNumber >= 60)
        {

            loseText.text = "Nice Try!";

        }
        else
        {

            loseText.text = "Good Effort!";

        }

        loseMenu.SetActive (true);
        
	}

    public void ResetGame() {

        if (scoreManager.highScoreKey == "FlightHighscore")
        {

            SceneManager.LoadScene("FlightMode");
            
        }

        loseMenu.SetActive(false);

        pauseButton.SetActive(true);

        platformList = FindObjectsOfType<ObjectDestroyer>();

        for (int i = 0; i < platformList.Length; i++)
        {

            platformList[i].gameObject.SetActive(false);

        }
            
        thePlayer.myRigidBody.transform.rotation = new Quaternion(0, 0, 0, 0);

        thePlayer.cancelJump = false;

        thePlayer.grounded = true;

        thePlayer.transform.position = playerStartPoint;

        platformGenerator.position = platformStartPoint;

        scoreManager.scoreCount = 0f;

        scoreManager.pointsPerSecond = scoreManager.pointsPerSecondStore;

        scoreManager.scoreIncreasing = true;

        thePlayer.gameObject.SetActive(true);

        Time.timeScale = 1f;
        
    }

    public void QuitToModeMenu()
    {

        SceneManager.LoadScene("ModeMenu");

    }

}
