using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Menus : MonoBehaviour {

	public AudioMixer musicAudioMixer;

	public AudioMixer soundEffectsAudioMixer;

	public GameObject settingsButton, settingsMenu, coinInfo, shopButton;

    public GameObject highscoreResetCheck, highscoreResetConfirmation;

	public Slider musicSlider, soundEffectsSlider;
   
    public GameObject normalModesButton, hardModesButtonRight, hardModesButtonLeft, coldModesButtonRight, coldModesButtonLeft, moonModesButton;

    public GameObject normalGameButtons, hardGameButtons, coldGameButtons, moonGameButtons;

    public GameObject normalBackground, hardBackground, coldBackground, moonBackground;

    public TextMeshProUGUI easyHighscoreText, normalHighscoreText, spikesHighscoreText, hardHighscoreText, intenseHighscoreText, insaneHighscoreText;
    
    public TextMeshProUGUI flippedHighscoreText, sprintHighscoreText, flightHighscoreText, spaceHighscoreText, moonHighscoreText, gravityHighscoreText;
    
    public TextMeshProUGUI numberOfJumpsText, nameText, coinsText;
    
    void Start () {
        
        settingsMenu.SetActive (false);

		musicAudioMixer.SetFloat ("Music", PlayerPrefs.GetFloat ("MusicVolume", 0f));

		musicSlider.value = PlayerPrefs.GetFloat ("MusicVolume", 0f);

		soundEffectsAudioMixer.SetFloat ("SoundEffects", PlayerPrefs.GetFloat ("SoundEffectsVolume", 0f));

		soundEffectsSlider.value = PlayerPrefs.GetFloat ("SoundEffectsVolume", 0f);

		coinsText.text = PlayerPrefs.GetInt ("NumberOfCoins", 0).ToString ();

    }

	public void SetMusicVolume (float musicVolume) {

		musicAudioMixer.SetFloat ("Music", musicVolume);

		PlayerPrefs.SetFloat ("MusicVolume", musicVolume);
	
	}

	public void SetSoundEffectsVolume (float soundEffectsVolume) {

		soundEffectsAudioMixer.SetFloat ("SoundEffects", soundEffectsVolume);

		PlayerPrefs.SetFloat ("SoundEffectsVolume", soundEffectsVolume);

	}

    public void ActivateSettingsMenu () {

        normalGameButtons.SetActive(false);
        hardGameButtons.SetActive(false);
        coldGameButtons.SetActive(false);
        moonGameButtons.SetActive(false);

        settingsButton.SetActive(false);

        normalModesButton.SetActive(false);
        hardModesButtonRight.SetActive(false);
        hardModesButtonLeft.SetActive(false);
        coldModesButtonRight.SetActive(false);
        coldModesButtonLeft.SetActive(false);
        moonModesButton.SetActive(false);

        coinInfo.SetActive(false);
        shopButton.SetActive(false);

        settingsMenu.SetActive (true);
	
	}

    public void HighScoreResetCheck () {
	
		settingsMenu.SetActive (false);

		highscoreResetCheck.SetActive (true);
	
	}

	public void CancelHighScoreReset () {
	
		highscoreResetCheck.SetActive (false);
	
		settingsMenu.SetActive (true);

	}

	public void HighScoreReset () {

		PlayerPrefs.DeleteKey ("EasyHighscore"); 

		PlayerPrefs.DeleteKey ("NormalHighscore"); 

		PlayerPrefs.DeleteKey ("SpikesHighscore"); 

		PlayerPrefs.DeleteKey ("HardHighscore"); 

		PlayerPrefs.DeleteKey ("IntenseHighscore"); 

		PlayerPrefs.DeleteKey ("InsaneHighscore");

        PlayerPrefs.DeleteKey("FlippedHighscore");

        PlayerPrefs.DeleteKey("Sprint2Highscore");

        PlayerPrefs.DeleteKey("FlightHighscore");

        PlayerPrefs.DeleteKey("SpaceHighscore");

        PlayerPrefs.DeleteKey("MoonHighscore");

        PlayerPrefs.DeleteKey("Gravity2Highscore");

        easyHighscoreText.text = "Highscore: " + Mathf.RoundToInt (PlayerPrefs.GetFloat ("EasyHighscore", 0f));

		normalHighscoreText.text = "Highscore: " + Mathf.RoundToInt (PlayerPrefs.GetFloat ("NormalHighscore", 0f));

		spikesHighscoreText.text = "Highscore: " + Mathf.RoundToInt (PlayerPrefs.GetFloat ("SpikesHighscore", 0f));

		hardHighscoreText.text = "Highscore: " + Mathf.RoundToInt (PlayerPrefs.GetFloat ("HardHighscore", 0f));

		intenseHighscoreText.text = "Highscore: " + Mathf.RoundToInt (PlayerPrefs.GetFloat ("IntenseHighscore", 0f));

		insaneHighscoreText.text = "Highscore: " + Mathf.RoundToInt (PlayerPrefs.GetFloat ("InsaneHighscore", 0f));

        flippedHighscoreText.text = "Highscore: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("FlippedHighscore", 0f));

        sprintHighscoreText.text = "Highscore: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("Sprint2Highscore", 0f));

        flightHighscoreText.text = "Highscore: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("FlightHighscore", 0f));

        spaceHighscoreText.text = "Highscore: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("SpaceHighscore", 0f));

        moonHighscoreText.text = "Highscore: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("MoonHighscore", 0f));

        gravityHighscoreText.text = "Highscore: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("Gravity2Highscore", 0f));

        highscoreResetCheck.SetActive (false);

		highscoreResetConfirmation.SetActive (true);

	}

	public void Back () {

        highscoreResetConfirmation.SetActive(false);
        settingsMenu.SetActive(false);

        if (PlayerPrefs.GetString ("ActiveMenuScreen") == "Normal")
        {

            normalGameButtons.SetActive(true);

            hardModesButtonRight.SetActive(true);
            
		}
        else if (PlayerPrefs.GetString("ActiveMenuScreen") == "Hard")
        {

            hardGameButtons.SetActive(true);

            normalModesButton.SetActive(true);
            coldModesButtonRight.SetActive(true);
            
        }
        else if (PlayerPrefs.GetString("ActiveMenuScreen") == "Moon")
        {

            moonGameButtons.SetActive(true);

            coldModesButtonLeft.SetActive(true);

        }
        else
        {
           
            coldGameButtons.SetActive(true);

            hardModesButtonLeft.SetActive(true);
            moonModesButton.SetActive(true);

        }
        
        settingsButton.SetActive(true);

        coinInfo.SetActive(true);
        shopButton.SetActive(true);

    }

}
