using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour {

	public GameObject blockoText;

	public GameObject clickToPlayText;

	public GameObject clickToPlayButton;

	public GameObject loadingScreen;

	public GameObject coins;

	public GameObject platforms;

	public GameObject blocko;

	public Slider loadingBar;

	public TextMeshProUGUI percentLoadedText;

    public Image skinModel;

    public Sprite[] skins;

    public GameObject[] modelHats;

    public void LoadModeMenu () {

		StartCoroutine (LoadAsynchronously ("ModeMenu"));

        for (int i = 0; i < skins.Length; i++)
        {

            if (skins[i].name == (PlayerPrefs.GetString("EquiptedSkin", "Blocko")))
            {

                skinModel.sprite = skins[i];

            }

        }

        for (int i = 0; i < modelHats.Length; i++)
        {

            modelHats[i].SetActive(false);

            if (modelHats[i].name == (PlayerPrefs.GetString("EquiptedHat", "None")))
            {

                modelHats[i].SetActive(true);

            }

        }

    }

	IEnumerator LoadAsynchronously (string sceneToLoad) {

		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneToLoad);

		coins.SetActive (false);

		platforms.SetActive (false);

		blocko.SetActive (false);

		blockoText.SetActive (false);

		clickToPlayText.SetActive (false);

		clickToPlayButton.SetActive (false);

		loadingScreen.SetActive (true);

		while (!operation.isDone) {

			float progress = Mathf.Clamp01 (operation.progress / 0.9f);

			loadingBar.value = progress;

			percentLoadedText.text = Mathf.RoundToInt(progress * 100f) + "%";

			yield return null;

		}

	}

}
