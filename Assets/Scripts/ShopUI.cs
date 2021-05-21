using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class ShopUI : MonoBehaviour {

    public SkinShopManager skinShop;
    
	public TextMeshProUGUI coinsText, shopText;

	public GameObject coinImage, costImage, model;

	public GameObject menuButton;

	public GameObject buttons;

	public GameObject skinShopScreen;

	public GameObject hatShopScreen;

    public GameObject trailShopScreen;

    public GameObject particleShopScreen;

	private GameObject activeMenu;

    public TextMeshProUGUI percentLoadedText;

    public Slider loadingBar;

    public GameObject loadingScreen;

    public Image skinModel, loadingSkin;
    
    public GameObject[] loadingHats, hats, trails, particles;

    public GameObject buttonParticles;

    public GameObject notEnoughCoinsScreen;
    
    void Start () {
       
        coinsText.text = PlayerPrefs.GetInt ("NumberOfCoins", 0).ToString ();

		activeMenu = skinShopScreen;

        foreach (Sprite i in skinShop.skinImages)
        {
            if (i.name == PlayerPrefs.GetString("EquiptedSkin", "Blocko"))
            {
                skinModel.sprite = i;
            }
        }

        foreach (GameObject i in hats)
        {
            if (i.name == PlayerPrefs.GetString("EquiptedHat", "None"))
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }

        }

        foreach (GameObject i in trails)
        {
            if (i.name == PlayerPrefs.GetString("EquiptedTrail", "None"))
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }

        }

        foreach (GameObject i in particles)
        {
            if (i.name == PlayerPrefs.GetString("EquiptedParticle", "None"))
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }

        }

    }

	public void OpenSkinShop () {

        shopText.gameObject.SetActive(true);

        activeMenu.SetActive (false);

        buttonParticles.SetActive(false);

        skinShopScreen.SetActive (true);

        costImage.SetActive(true);

        model.SetActive(true);

        shopText.text = "Skin Shop";

        activeMenu = skinShopScreen;

        foreach (GameObject i in particles)
        {
            if (i.name == PlayerPrefs.GetString("EquiptedParticle", "None"))
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }

        }

    }

	public void OpenHatShop () {

        shopText.gameObject.SetActive(true);

        activeMenu.SetActive (false);

        buttonParticles.SetActive(false);

        hatShopScreen.SetActive (true);

        costImage.SetActive(true);

        model.SetActive(true);

        shopText.text = "Hat Shop";

        activeMenu = hatShopScreen;

        foreach (GameObject i in particles)
        {
            if (i.name == PlayerPrefs.GetString("EquiptedParticle", "None"))
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }

        }

    }

    public void OpenTrailShop()
    {

        shopText.gameObject.SetActive(true);

        activeMenu.SetActive(false);

        buttonParticles.SetActive(false);

        trailShopScreen.SetActive(true);

        costImage.SetActive(true);

        model.SetActive(true);

        shopText.text = "Trail Shop";

        activeMenu = trailShopScreen;

        foreach (GameObject i in particles)
        {
            if (i.name == PlayerPrefs.GetString("EquiptedParticle", "None"))
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }

        }

    }

    public void OpenParticleShop()
    {

        shopText.gameObject.SetActive(true);

        activeMenu.SetActive(false);

        particleShopScreen.SetActive(true);

        costImage.SetActive(true);

        model.SetActive(true);

        buttonParticles.SetActive(true);

        shopText.text = "Particle Shop";

        activeMenu = particleShopScreen;

        foreach (GameObject i in particles)
        {
            if (i.name == PlayerPrefs.GetString("EquiptedParticle", "None"))
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }

        }

    }

	public void Back () {
        
		activeMenu.SetActive (true);

        if (activeMenu == particleShopScreen)
        {

            buttonParticles.SetActive(true);

        }

        costImage.SetActive(true);

        buttons.SetActive (true);

		menuButton.SetActive (true);

        shopText.gameObject.SetActive(true);

        coinImage.SetActive(true);

        model.SetActive(true);

        foreach (GameObject i in particles)
        {
            if (i.name == PlayerPrefs.GetString("EquiptedParticle", "None"))
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }

        }

    }

	public void QuitToMainMenu () {

        StartCoroutine(LoadAsynchronously("ModeMenu"));

        foreach (Sprite i in skinShop.skinImages)
        {
            if (i.name == PlayerPrefs.GetString("EquiptedSkin", "Blocko"))
            {
                loadingSkin.sprite = i;
            }
        }

        foreach (GameObject i in loadingHats)
        {
            if (i.name == PlayerPrefs.GetString("EquiptedHat", "None"))
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }

        }

    }

    IEnumerator LoadAsynchronously(string sceneToLoad)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);

        costImage.SetActive(false);

        model.SetActive(false);

        shopText.gameObject.SetActive(false);

        activeMenu.SetActive(false);

        buttonParticles.SetActive(false);

        menuButton.SetActive(false);

        buttons.SetActive(false);

        coinImage.SetActive(false);

        foreach (GameObject i in particles)
        {

            i.SetActive(false);

        }
        
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBar.value = progress;

            percentLoadedText.text = Mathf.RoundToInt(progress * 100f) + "%";

            yield return null;

        }

    }

    public void NotEnoughCoins()
    {

        costImage.SetActive(false);

        model.SetActive(false);

        shopText.gameObject.SetActive(false);

        activeMenu.SetActive(false);

        buttonParticles.SetActive(false);

        menuButton.SetActive(false);

        buttons.SetActive(false);

        coinImage.SetActive(false);

        notEnoughCoinsScreen.SetActive(true);

    }

    public void ExitNEC()
    {

        notEnoughCoinsScreen.SetActive(false);

        costImage.SetActive(true);

        model.SetActive(true);

        shopText.gameObject.SetActive(true);

        activeMenu.SetActive(true);

        if (activeMenu == particleShopScreen)
        {

            buttonParticles.SetActive(true);

        }

        menuButton.SetActive(true);

        buttons.SetActive(true);

        coinImage.SetActive(true);

    }

}
