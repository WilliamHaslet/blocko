using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ModePicker : MonoBehaviour {

	public Animator fadeAnimator;

	public Slider loadingBar;

	public GameObject loadingScreen;

	public GameObject normalGameButtons, hardGameButtons, coldGameButtons, moonGameButtons;
    
	public GameObject settingsButton, coinInfo;
    
	public TextMeshProUGUI coinsText;

	public TextMeshProUGUI easyHighscoreText, normalHighscoreText, spikesHighscoreText, hardHighscoreText, intenseHighscoreText, insaneHighscoreText;

    public TextMeshProUGUI flippedHighscoreText, sprintHighscoreText, flightHighscoreText, spaceHighscoreText, moonHighscoreText, gravityHighscoreText;

    public GameObject shopButton;
    
	public GameObject normalModesButton, hardModesButtonRight, hardModesButtonLeft, coldModesButtonRight, coldModesButtonLeft, moonModesButton;

	public TextMeshProUGUI percentLoadedText;

    public GameObject normalBackground, hardBackground, coldBackground, moonBackground;
    
	public Sprite[] skins;

	public Image normalSkinModel, hardModeSkinModel, coldModeSkinModel, moonModeSkinModel, loadingModeSkinModel;
    
	public GameObject[] normalModeHats;

	public GameObject[] hardModeModelHats;

    public GameObject[] coldModeModelHats;

    public GameObject[] moonModeModelHats;

    public GameObject[] loadingModeModelHats;

    public TMP_InputField choosenName;

    public GameObject nameTaken;

    public GameObject confirmNameButton;
    
    void Start () {
        
        /*new GameSparks.Api.Requests.AuthenticationRequest()
            .SetUserName(PlayerPrefs.GetString("Name"))
            .SetPassword(PlayerPrefs.GetString("Name"))
            .Send((response) => {

                if (!response.HasErrors)
                {
                    Debug.Log("Player Authenticated...");
                }
                else
                {
                    Debug.Log("Error Authenticating Player...");
                }
            });*/

        if (PlayerPrefs.GetInt("NumberOfCoins", 0) < 0)
        {

            PlayerPrefs.SetInt("NumberOfCoins", 0);

        }

        coinsText.text = PlayerPrefs.GetInt ("NumberOfCoins", 0).ToString ();

		if (PlayerPrefs.GetString ("ActiveMenuScreen", "Normal") == "Normal") {

            normalModesButton.SetActive(false);
            hardModesButtonRight.SetActive(false);
            hardModesButtonLeft.SetActive(false);
            coldModesButtonRight.SetActive(false);
            coldModesButtonLeft.SetActive(false);
            moonModesButton.SetActive(false);

            hardGameButtons.SetActive(false);
            coldGameButtons.SetActive(false);
            moonGameButtons.SetActive(false);

            hardBackground.SetActive(false);
            coldBackground.SetActive(false);
            moonBackground.SetActive(false);

            normalBackground.SetActive(true);
            normalGameButtons.SetActive(true);

            hardModesButtonRight.SetActive(true);

        }
        else if (PlayerPrefs.GetString("ActiveMenuScreen") == "Hard")
        {

            normalModesButton.SetActive(false);
            hardModesButtonRight.SetActive(false);
            hardModesButtonLeft.SetActive(false);
            coldModesButtonRight.SetActive(false);
            coldModesButtonLeft.SetActive(false);
            moonModesButton.SetActive(false);

            normalGameButtons.SetActive(false);
            coldGameButtons.SetActive(false);
            moonGameButtons.SetActive(false);

            normalBackground.SetActive(false);
            coldBackground.SetActive(false);
            moonBackground.SetActive(false);

            hardBackground.SetActive(true);
            hardGameButtons.SetActive(true);

            normalModesButton.SetActive(true);
            coldModesButtonRight.SetActive(true);

        }
        else if (PlayerPrefs.GetString("ActiveMenuScreen") == "Moon")
        {

            normalModesButton.SetActive(false);
            hardModesButtonRight.SetActive(false);
            hardModesButtonLeft.SetActive(false);
            coldModesButtonRight.SetActive(false);
            coldModesButtonLeft.SetActive(false);
            moonModesButton.SetActive(false);

            hardGameButtons.SetActive(false);
            coldGameButtons.SetActive(false);
            normalGameButtons.SetActive(false);

            hardBackground.SetActive(false);
            coldBackground.SetActive(false);
            normalBackground.SetActive(false);

            moonBackground.SetActive(true);
            moonGameButtons.SetActive(true);

            coldModesButtonLeft.SetActive(true);

        }
        else
        {

            normalModesButton.SetActive(false);
            hardModesButtonRight.SetActive(false);
            hardModesButtonLeft.SetActive(false);
            coldModesButtonRight.SetActive(false);
            coldModesButtonLeft.SetActive(false);
            moonModesButton.SetActive(false);

            hardGameButtons.SetActive(false);
            normalGameButtons.SetActive(false);
            moonGameButtons.SetActive(false);

            hardBackground.SetActive(false);
            normalBackground.SetActive(false);
            moonBackground.SetActive(false);

            coldBackground.SetActive(true);
            coldGameButtons.SetActive(true);

            hardModesButtonLeft.SetActive(true);
            moonModesButton.SetActive(true);

        }

		for (int i = 0; i < skins.Length; i++) {

			if (skins [i].name == (PlayerPrefs.GetString ("EquiptedSkin", "Blocko"))) {

				normalSkinModel.sprite = skins [i];

				hardModeSkinModel.sprite = skins [i];

                coldModeSkinModel.sprite = skins[i];

                moonModeSkinModel.sprite = skins[i];

                loadingModeSkinModel.sprite = skins[i];

            }

		}

		for (int i = 0; i < normalModeHats.Length; i++) {

            normalModeHats[i].SetActive (false);

			if (normalModeHats[i].name == (PlayerPrefs.GetString ("EquiptedHat", "None"))) {

                normalModeHats[i].SetActive (true);

			}

		}

		for (int i = 0; i < hardModeModelHats.Length; i++) {

			hardModeModelHats [i].SetActive (false);

			if (hardModeModelHats [i].name == (PlayerPrefs.GetString ("EquiptedHat", "None"))) {

				hardModeModelHats [i].SetActive (true);

			}

		}

        for (int i = 0; i < coldModeModelHats.Length; i++)
        {

            coldModeModelHats[i].SetActive(false);

            if (coldModeModelHats[i].name == (PlayerPrefs.GetString("EquiptedHat", "None")))
            {

                coldModeModelHats[i].SetActive(true);

            }

        }

        for (int i = 0; i < moonModeModelHats.Length; i++)
        {

            moonModeModelHats[i].SetActive(false);

            if (moonModeModelHats[i].name == (PlayerPrefs.GetString("EquiptedHat", "None")))
            {

                moonModeModelHats[i].SetActive(true);

            }

        }

        for (int i = 0; i < loadingModeModelHats.Length; i++)
        {

            loadingModeModelHats[i].SetActive(false);

            if (loadingModeModelHats[i].name == (PlayerPrefs.GetString("EquiptedHat", "None")))
            {

                loadingModeModelHats[i].SetActive(true);

            }

        }

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

        /*new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SUBMIT_EASY_AT")
                .SetEventAttribute("EASY_SCORE_AT", PlayerPrefs.GetFloat("EasyHighscore", 0f).ToString("0"))
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Easy AT Score Posted Successfully...");
                    }
                    else
                    {
                        Debug.Log("Easy AT Error Posting Score...");
                    }

                });

        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SUBMIT_NORMAL_AT")
            .SetEventAttribute("NORMAL_SCORE_AT", PlayerPrefs.GetFloat("NormalHighscore", 0f).ToString("0"))
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Normal AT Score Posted Successfully...");
                }
                else
                {
                    Debug.Log("Normal AT Error Posting Score...");
                }

            });

        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SUBMIT_SPIKES_AT")
            .SetEventAttribute("SPIKES_SCORE_AT", PlayerPrefs.GetFloat("SpikesHighscore", 0f).ToString("0"))
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Spikes AT Score Posted Successfully...");
                }
                else
                {
                    Debug.Log("Spikes AT Error Posting Score...");
                }

            });

        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SUBMIT_HARD_AT")
            .SetEventAttribute("HARD_SCORE_AT", PlayerPrefs.GetFloat("HardHighscore", 0f).ToString("0"))
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Hard AT Score Posted Successfully...");
                }
                else
                {
                    Debug.Log("Hard AT Error Posting Score...");
                }

            });

        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SUBMIT_INTENSE_AT")
            .SetEventAttribute("INTENSE_SCORE_AT", PlayerPrefs.GetFloat("IntenseHighscore", 0f).ToString("0"))
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Intense AT Score Posted Successfully...");
                }
                else
                {
                    Debug.Log("Intense AT Error Posting Score...");
                }

            });

        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SUBMIT_INSANE_AT")
            .SetEventAttribute("INSANE_SCORE_AT", PlayerPrefs.GetFloat("InsaneHighscore", 0f).ToString("0"))
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Insane AT Score Posted Successfully...");
                }
                else
                {
                    Debug.Log("Insane AT Error Posting Score...");
                }

            });

        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SUBMIT_FLIPPED_AT")
            .SetEventAttribute("FLIPPED_SCORE_AT", PlayerPrefs.GetFloat("FlippedHighscore", 0f).ToString("0"))
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Flipped AT Score Posted Successfully...");
                }
                else
                {
                    Debug.Log("Flipped AT Error Posting Score...");
                }

            });

        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SUBMIT_SPRINT_AT")
            .SetEventAttribute("SPRINT_SCORE_AT", PlayerPrefs.GetFloat("Sprint2Highscore", 0f).ToString("0"))
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Sprint AT Score Posted Successfully...");
                }
                else
                {
                    Debug.Log("Sprint AT Error Posting Score...");
                }

            });

        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SUBMIT_FLIGHT_AT")
            .SetEventAttribute("FLIGHT_SCORE_AT", PlayerPrefs.GetFloat("FlightHighscore", 0f).ToString("0"))
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Flight AT Score Posted Successfully...");
                }
                else
                {
                    Debug.Log("Flight AT Error Posting Score...");
                }

            });

        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SUBMIT_SPACE_AT")
            .SetEventAttribute("SPACE_SCORE_AT", PlayerPrefs.GetFloat("SpaceHighscore", 0f).ToString("0"))
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Space AT Score Posted Successfully...");
                }
                else
                {
                    Debug.Log("Space AT Error Posting Score...");
                }

            });

        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SUBMIT_MOON_AT")
            .SetEventAttribute("MOON_SCORE_AT", PlayerPrefs.GetFloat("MoonHighscore", 0f).ToString("0"))
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Moon AT Score Posted Successfully...");
                }
                else
                {
                    Debug.Log("Moon AT Error Posting Score...");
                }

            });

        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SUBMIT_GRAVITY_AT")
            .SetEventAttribute("GRAVITY_SCORE_AT", PlayerPrefs.GetFloat("Gravity2Highscore", 0f).ToString("0"))
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Gravity AT Score Posted Successfully...");
                }
                else
                {
                    Debug.Log("Gravity AT Error Posting Score...");
                }

            });*/

    }

    public void ChooseName()
    {

        PlayerPrefs.SetString("Name", choosenName.text);

        /*new GameSparks.Api.Requests.RegistrationRequest()
          .SetDisplayName(choosenName.text)
          .SetPassword(choosenName.text)
          .SetUserName(choosenName.text)
          .Send((response) => {
              if (!response.HasErrors)
              {
                  Debug.Log("Player Registered");

                  PlayerPrefs.SetInt("PlayerHasChoosenName2", 1);

                  StartCoroutine(LoadAsynchronously("Tutorial"));
              }
              else
              {
                  Debug.Log("Error Registering Player");

                  confirmNameButton.SetActive(false);

                  nameTaken.SetActive(true);
              }

          });*/
        
    }

    public void SetConfirmActive()
    {

        nameTaken.SetActive(false);

        confirmNameButton.SetActive(true);

    }

    public void ReplayTutorial()
    {

        StartCoroutine(LoadAsynchronously("Tutorial"));

    }

    public void LoadShop () {

		StartCoroutine (LoadAsynchronously ("Shop"));

	}
    
    public void HardModesScreen () {

        normalModesButton.SetActive(false);
        hardModesButtonRight.SetActive(false);
        hardModesButtonLeft.SetActive(false);
        coldModesButtonRight.SetActive(false);
        coldModesButtonLeft.SetActive(false);
        moonModesButton.SetActive(false);

        normalGameButtons.SetActive(false);
        coldGameButtons.SetActive(false);
        moonGameButtons.SetActive(false);

        normalBackground.SetActive(false);
        coldBackground.SetActive(false);
        moonBackground.SetActive(false);

        hardBackground.SetActive(true);
        hardGameButtons.SetActive(true);

        normalModesButton.SetActive(true);
        coldModesButtonRight.SetActive(true);

        PlayerPrefs.SetString ("ActiveMenuScreen", "Hard");
	
	}

	public void NormalModesScreen () {

        normalModesButton.SetActive(false);
        hardModesButtonRight.SetActive(false);
        hardModesButtonLeft.SetActive(false);
        coldModesButtonRight.SetActive(false);
        coldModesButtonLeft.SetActive(false);
        moonModesButton.SetActive(false);

        hardGameButtons.SetActive(false);
        coldGameButtons.SetActive(false);
        moonGameButtons.SetActive(false);

        hardBackground.SetActive(false);
        coldBackground.SetActive(false);
        moonBackground.SetActive(false);

        normalBackground.SetActive(true);
        normalGameButtons.SetActive(true);

        hardModesButtonRight.SetActive(true);

        PlayerPrefs.SetString ("ActiveMenuScreen", "Normal");
	
	}

    public void ColdModesScreen()
    {

        normalModesButton.SetActive(false);
        hardModesButtonRight.SetActive(false);
        hardModesButtonLeft.SetActive(false);
        coldModesButtonRight.SetActive(false);
        coldModesButtonLeft.SetActive(false);
        moonModesButton.SetActive(false);

        hardGameButtons.SetActive(false);
        normalGameButtons.SetActive(false);
        moonGameButtons.SetActive(false);

        hardBackground.SetActive(false);
        normalBackground.SetActive(false);
        moonBackground.SetActive(false);

        coldBackground.SetActive(true);
        coldGameButtons.SetActive(true);

        hardModesButtonLeft.SetActive(true);
        moonModesButton.SetActive(true);

        PlayerPrefs.SetString("ActiveMenuScreen", "Cold");

    }

    public void MoonModesScreen()
    {

        normalModesButton.SetActive(false);
        hardModesButtonRight.SetActive(false);
        hardModesButtonLeft.SetActive(false);
        coldModesButtonRight.SetActive(false);
        coldModesButtonLeft.SetActive(false);
        moonModesButton.SetActive(false);

        hardGameButtons.SetActive(false);
        coldGameButtons.SetActive(false);
        normalGameButtons.SetActive(false);

        hardBackground.SetActive(false);
        coldBackground.SetActive(false);
        normalBackground.SetActive(false);

        moonBackground.SetActive(true);
        moonGameButtons.SetActive(true);

        coldModesButtonLeft.SetActive(true);

        PlayerPrefs.SetString("ActiveMenuScreen", "Moon");

    }

    public void LoadEasyMode () {

		StartCoroutine (LoadAsynchronously ("EasyMode"));

	}

	public void LoadNormalMode () {

		StartCoroutine (LoadAsynchronously ("NormalMode"));

	}

	public void LoadSpikesMode () {

		StartCoroutine (LoadAsynchronously ("SpikesMode"));

	}

	public void LoadHardMode () {

		StartCoroutine (LoadAsynchronously ("HardMode"));

	}
		
	public void LoadIntenseMode () {

		StartCoroutine (LoadAsynchronously ("IntenseMode"));

	}

	public void LoadInsaneMode () {

		StartCoroutine (LoadAsynchronously ("InsaneMode"));

	}

    public void LoadFlippedMode()
    {

        StartCoroutine(LoadAsynchronously("FlippedMode"));

    }

    public void LoadSprintMode()
    {

        StartCoroutine(LoadAsynchronously("SprintMode"));

    }

    public void LoadFlightMode()
    {

        StartCoroutine(LoadAsynchronously("FlightMode"));

    }

    public void LoadSpaceMode()
    {

        StartCoroutine(LoadAsynchronously("SpaceMode"));

    }

    public void LoadMoonMode()
    {

        StartCoroutine(LoadAsynchronously("MoonMode"));

    }

    public void LoadGravityMode()
    {

        StartCoroutine(LoadAsynchronously("GravityMode"));

    }

    IEnumerator LoadAsynchronously (string sceneToLoad) {

		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneToLoad);

        moonModesButton.SetActive(false);
        hardGameButtons.SetActive(false);
        coldGameButtons.SetActive(false);
        normalGameButtons.SetActive(false);
        moonGameButtons.SetActive(false);
        hardModesButtonRight.SetActive(false);
        hardModesButtonLeft.SetActive(false);
        coldModesButtonRight.SetActive(false);
        coldModesButtonLeft.SetActive(false);
        normalModesButton.SetActive(false);
        settingsButton.SetActive (false);
		coinInfo.SetActive (false);
		shopButton.SetActive (false);

        if (PlayerPrefs.GetString("ActiveMenuScreen") == "Normal")
        {

            hardBackground.SetActive(false);
            coldBackground.SetActive(false);
            moonBackground.SetActive(false);

        }
        else if (PlayerPrefs.GetString("ActiveMenuScreen") == "Hard")
        {
            
            coldBackground.SetActive(false);
            normalBackground.SetActive(false);
            moonBackground.SetActive(false);

        }
        else if (PlayerPrefs.GetString("ActiveMenuScreen") == "Moon")
        {

            hardBackground.SetActive(false);
            coldBackground.SetActive(false);
            normalBackground.SetActive(false);

        }
        else
        {

            hardBackground.SetActive(false);
            normalBackground.SetActive(false);
            moonBackground.SetActive(false);

        }

        loadingScreen.SetActive (true);

		while (!operation.isDone) {

			float progress = Mathf.Clamp01 (operation.progress / 0.9f);

			loadingBar.value = progress;

			percentLoadedText.text = Mathf.RoundToInt(progress * 100f) + "%";

			yield return null;

		}

	}

}
