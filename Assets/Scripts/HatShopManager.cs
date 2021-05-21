using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HatShopManager : MonoBehaviour {

    public TextMeshProUGUI activeHatNameText, activeHatCostText;

    public GameObject buyButton, equipButton;

    public string acitveHatName;

    public int activeHatCost;
    
    public ShopUI shop;

    public void ClickNoneHat()
    {
        acitveHatName = "None";
        activeHatCost = 0;

        AcitvateButton();
    }

    public void ClickFedoraHat()
    {
        acitveHatName = "Fedora";
        activeHatCost = 500;

        AcitvateButton();
    }

    public void ClickBeretHat()
    {
        acitveHatName = "Beret";
        activeHatCost = 500;

        AcitvateButton();
    }

    public void ClickTopHat()
    {
        acitveHatName = "Top Hat";
        activeHatCost = 500;

        AcitvateButton();
    }

    public void ClickTrilbyHat()
    {
        acitveHatName = "Trilby";
        activeHatCost = 500;

        AcitvateButton();
    }

    public void ClickBowlerHat()
    {
        acitveHatName = "Bowler";
        activeHatCost = 500;

        AcitvateButton();
    }

    public void ClickGraduationcap()
    {
        acitveHatName = "Graduation Cap";
        activeHatCost = 500;

        AcitvateButton();
    }

    public void ClickBaseballCap()
    {
        acitveHatName = "Baseball Cap";
        activeHatCost = 500;

        AcitvateButton();
    }

    public void ClickBeanieHat()
    {
        acitveHatName = "Beanie";
        activeHatCost = 500;

        AcitvateButton();
    }

    public void ClickBoaterHat()
    {
        acitveHatName = "Boater";
        activeHatCost = 1000;

        AcitvateButton();
    }

    public void ClickCoinHat()
    {
        acitveHatName = "Coin";
        activeHatCost = 1000;

        AcitvateButton();
    }

    public void ClickSpikesHat()
    {
        acitveHatName = "Spikes";
        activeHatCost = 1000;

        AcitvateButton();
    }

    public void ClickBlockoHat()
    {
        acitveHatName = "Blocko";
        activeHatCost = 1000;

        AcitvateButton();
    }

    public void ClickCampaignHat()
    {
        acitveHatName = "Campaign Hat";
        activeHatCost = 1500;

        AcitvateButton();
    }

    public void ClickPilgrimHat()
    {
        acitveHatName = "Pilgrim Hat";
        activeHatCost = 1500;

        AcitvateButton();
    }

    public void ClickHelmet()
    {
        acitveHatName = "Helmet";
        activeHatCost = 1500;

        AcitvateButton();
    }

    public void ClickCowboyHat()
    {
        acitveHatName = "Cowboy Hat";
        activeHatCost = 2000;

        AcitvateButton();
    }

    public void ClickMitre()
    {
        acitveHatName = "Mitre";
        activeHatCost = 2000;

        AcitvateButton();
    }

    public void ClickDeerstalker()
    {
        acitveHatName = "Deerstalker";
        activeHatCost = 2000;

        AcitvateButton();
    }

    public void ClickCoonskinCap()
    {
        acitveHatName = "Coonskin Cap";
        activeHatCost = 3000;

        AcitvateButton();
    }

    public void ClickCloche()
    {
        acitveHatName = "Cloche";
        activeHatCost = 3000;

        AcitvateButton();
    }

    public void ClickFez()
    {
        acitveHatName = "Fez";
        activeHatCost = 3000;

        AcitvateButton();
    }

    public void ClickSombrero()
    {
        acitveHatName = "Sombrero";
        activeHatCost = 5000;

        AcitvateButton();
    }

    public void ClickCrown()
    {
        acitveHatName = "Crown";
        activeHatCost = 10000;

        AcitvateButton();
    }

    public void AcitvateButton()
    {
        activeHatNameText.text = acitveHatName;
        activeHatCostText.text = activeHatCost.ToString();

        foreach (GameObject i in shop.hats)
        {
            if (i.name == acitveHatName)
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }
        }

        if (PlayerPrefs.GetInt(acitveHatName + "Purchased") == 0)
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

    public void BuyHat()
    {

        int coins = PlayerPrefs.GetInt("NumberOfCoins", 0);

        if (coins < activeHatCost)
        {

            shop.NotEnoughCoins();

        }
        else
        {

            PlayerPrefs.SetInt(acitveHatName + "Purchased", 1);
            
            coins -= activeHatCost;

            PlayerPrefs.SetInt("NumberOfCoins", coins);

            PlayerPrefs.SetString("EquiptedHat", acitveHatName);

            buyButton.SetActive(false);

            equipButton.SetActive(false);

            shop.coinsText.text = PlayerPrefs.GetInt("NumberOfCoins", 0).ToString();

        }

    }

    public void EquipHat()
    {
        PlayerPrefs.SetString("EquiptedHat", acitveHatName);

        equipButton.SetActive(false);
    }

}
