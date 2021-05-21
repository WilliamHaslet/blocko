using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

	public TextMeshProUGUI scoreText, highScoreText, coinsText;

	public float scoreCount, highScoreCount, pointsPerSecond, pointsPerSecondStore;
    
	public bool scoreIncreasing, shouldDoubleCoins, isHighscore;
    
	public string highScoreKey;

	private int numberOfCoins;
    
	void Start () {
		
		highScoreCount = PlayerPrefs.GetFloat (highScoreKey, 0f);

        numberOfCoins = PlayerPrefs.GetInt ("NumberOfCoins", 0);

		pointsPerSecondStore = pointsPerSecond;

	}
	
	void FixedUpdate () {

		if (scoreIncreasing) {
			
			scoreCount += pointsPerSecond * Time.deltaTime;

		}

		if (scoreCount > highScoreCount) {

            highScoreCount = scoreCount;

            PlayerPrefs.SetFloat(highScoreKey, highScoreCount);

            isHighscore = true;
		
		}

		scoreText.text = Mathf.RoundToInt (scoreCount).ToString ();

		highScoreText.text = "Highscore: " + highScoreCount.ToString("f0");

		coinsText.text = numberOfCoins.ToString();

		PlayerPrefs.SetInt ("NumberOfCoins", numberOfCoins);

	}

	public void AddScore (int pointsToAdd, int coinsToAdd) {

		if (shouldDoubleCoins) {
		
			pointsToAdd *= 2;

			coinsToAdd *= 2;
	
		}

		scoreCount += pointsToAdd;

		numberOfCoins += coinsToAdd;

	}

}
