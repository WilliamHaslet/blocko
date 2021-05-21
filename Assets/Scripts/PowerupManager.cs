using TMPro;
using UnityEngine;

public class PowerupManager : MonoBehaviour {

	public ScoreManager scoreManager;

	public PlatformGenerator thePG;

	public GameplayManager theGM;

	public float currentPointsPerSecond;

	private float originalSpikeRate;

	private ObjectDestroyer[] spikeList;

	public bool activatePointsPowerup;

	public float pointsPowerupLengthCounter;

	public float pointsPowerupTime;

	public bool activateSpikesPowerup;

	public float spikesPowerupLengthCounter;

	public float spikesPowerupTime;

	public AudioSource powerupSound;

    public GameObject noSpikesHUD;

    public GameObject doublePointsHUD;

    public TextMeshProUGUI noSpikesTimerText;

    public TextMeshProUGUI doublePointsTimerText;

    public TextMeshProUGUI multiplierText;

    private int doublePointsMuliplier;
    
	void Start () {

		originalSpikeRate = thePG.randomSpikeThreshold;

		pointsPowerupLengthCounter = pointsPowerupTime;

		currentPointsPerSecond = scoreManager.pointsPerSecond;

        doublePointsMuliplier = 1;

    }
	
	void Update () {

		if (activatePointsPowerup)
        {
		
			pointsPowerupLengthCounter -= Time.deltaTime;

            doublePointsTimerText.text = pointsPowerupLengthCounter.ToString("f1");
            
			if (pointsPowerupLengthCounter <= 0f)
            {

                activatePointsPowerup = false;

                doublePointsHUD.SetActive(false);
                
				scoreManager.pointsPerSecond = currentPointsPerSecond;

                scoreManager.shouldDoubleCoins = false;

                pointsPowerupLengthCounter = pointsPowerupTime;

                doublePointsMuliplier = 1;
             
			}

		}

		if (activateSpikesPowerup)
        {

			spikesPowerupLengthCounter -= Time.deltaTime;

            noSpikesTimerText.text = spikesPowerupLengthCounter.ToString("f1");
            
            if (spikesPowerupLengthCounter <= 0f)
            {

                activateSpikesPowerup = false;

                noSpikesHUD.SetActive(false);

                thePG.randomSpikeThreshold = originalSpikeRate;
                
				spikesPowerupLengthCounter = 0;
			
			}
		
		}
	
	}
    
	public void DoublePointsPowerup () {

		powerupSound.Play ();

        scoreManager.pointsPerSecond *= 2f;

        scoreManager.shouldDoubleCoins = true;

        doublePointsMuliplier *= 2;

        multiplierText.text = doublePointsMuliplier.ToString() + "x";

        activatePointsPowerup = true;

        doublePointsHUD.SetActive(true);

    }

	public void NoSpikesPowerup () {

		powerupSound.Play ();

        spikesPowerupLengthCounter += spikesPowerupTime;
        
		thePG.randomSpikeThreshold = 0f;

		spikeList = FindObjectsOfType<ObjectDestroyer> ();

		for (int i = 0; i < spikeList.Length; i++) {

			if (spikeList [i].gameObject.name.Contains ("PlatformSpikes")) {

				spikeList [i].gameObject.SetActive (false);

			}

		}

        activateSpikesPowerup = true;

        noSpikesHUD.SetActive(true);

    }

}
