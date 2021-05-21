using UnityEngine;
using TMPro;

public class ParticleShopManager : MonoBehaviour {

    public TextMeshProUGUI activeParticleNameText, activeParticleCostText;

    public GameObject buyButton, equipButton;

    public string acitveParticleName;

    public int activeParticleCost;
    
    public ShopUI shop;

    public void ClickNoneParticle()
    {
        acitveParticleName = "None";
        activeParticleCost = 0;

        AcitvateButton();
    }

    public void ClickRedParticle()
    {
        acitveParticleName = "Red Particles";
        activeParticleCost = 500;

        AcitvateButton();
    }

    public void ClickOrangeParticle()
    {
        acitveParticleName = "Orange Particles";
        activeParticleCost = 500;

        AcitvateButton();
    }

    public void ClickYellowParticle()
    {
        acitveParticleName = "Yellow Particles";
        activeParticleCost = 500;

        AcitvateButton();
    }

    public void ClickGreenParticle()
    {
        acitveParticleName = "Green Particles";
        activeParticleCost = 500;

        AcitvateButton();
    }

    public void ClickBlueParticle()
    {
        acitveParticleName = "Blue Particles";
        activeParticleCost = 500;

        AcitvateButton();
    }

    public void ClickPurpleParticle()
    {
        acitveParticleName = "Purple Particles";
        activeParticleCost = 500;

        AcitvateButton();
    }

    public void ClickConfettiParticle()
    {
        acitveParticleName = "Confetti Particles";
        activeParticleCost = 1000;

        AcitvateButton();
    }

    public void ClickCoinParticle()
    {
        acitveParticleName = "Coin Particles";
        activeParticleCost = 1000;

        AcitvateButton();
    }

    public void ClickBlockoParticle()
    {
        acitveParticleName = "Blocko Particles";
        activeParticleCost = 1000;

        AcitvateButton();
    }

    public void AcitvateButton()
    {
        activeParticleNameText.text = acitveParticleName;
        activeParticleCostText.text = activeParticleCost.ToString();

        foreach (GameObject i in shop.particles)
        {
            if (i.name == acitveParticleName)
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }
        }

        if (PlayerPrefs.GetInt(acitveParticleName + "Purchased") == 0)
        {
            equipButton.SetActive(false);

            buyButton.SetActive(true);
        }
        else
        {
            buyButton.SetActive(false);

            equipButton.SetActive(true);
        }

    }

    public void BuyParticle()
    {

        int coins = PlayerPrefs.GetInt("NumberOfCoins", 0);

        if (coins < activeParticleCost)
        {

            shop.NotEnoughCoins();

        }
        else
        {

            PlayerPrefs.SetInt(acitveParticleName + "Purchased", 1);

            coins -= activeParticleCost;

            PlayerPrefs.SetInt("NumberOfCoins", coins);

            PlayerPrefs.SetString("EquiptedParticle", acitveParticleName);

            buyButton.SetActive(false);

            equipButton.SetActive(false);

            shop.coinsText.text = PlayerPrefs.GetInt("NumberOfCoins", 0).ToString();

        }

    }

    public void EquipParticle()
    {
        PlayerPrefs.SetString("EquiptedParticle", acitveParticleName);

        equipButton.SetActive(false);
    }

}
