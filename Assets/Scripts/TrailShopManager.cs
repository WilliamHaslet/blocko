using UnityEngine;
using TMPro;

public class TrailShopManager : MonoBehaviour {

    public TextMeshProUGUI activeTrailNameText, activeTrailCostText;

    public GameObject buyButton, equipButton;

    public string acitveTrailName;

    public int activeTrailCost;
    
    public ShopUI shop;

    public void ClickNoneTrail()
    {
        acitveTrailName = "None";
        activeTrailCost = 0;

        AcitvateButton();
    }

    public void ClickRedTrail()
    {
        acitveTrailName = "Red Trail";
        activeTrailCost = 500;

        AcitvateButton();
    }

    public void ClickOrangeTrail()
    {
        acitveTrailName = "Orange Trail";
        activeTrailCost = 500;

        AcitvateButton();
    }

    public void ClickYellowTrail()
    {
        acitveTrailName = "Yellow Trail";
        activeTrailCost = 500;

        AcitvateButton();
    }

    public void ClickGreenTrail()
    {
        acitveTrailName = "Green Trail";
        activeTrailCost = 500;

        AcitvateButton();
    }

    public void ClickBlueTrail()
    {
        acitveTrailName = "Blue Trail";
        activeTrailCost = 500;

        AcitvateButton();
    }

    public void ClickPurpleTrail()
    {
        acitveTrailName = "Purple Trail";
        activeTrailCost = 500;

        AcitvateButton();
    }

    public void AcitvateButton()
    {
        activeTrailNameText.text = acitveTrailName;
        activeTrailCostText.text = activeTrailCost.ToString();

        foreach (GameObject i in shop.trails)
        {
            if (i.name == acitveTrailName)
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }
        }

        if (PlayerPrefs.GetInt(acitveTrailName + "Purchased") == 0)
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

    public void BuyTrail()
    {

        int coins = PlayerPrefs.GetInt("NumberOfCoins", 0);

        if (coins < activeTrailCost)
        {

            shop.NotEnoughCoins();

        }
        else
        {

            PlayerPrefs.SetInt(acitveTrailName + "Purchased", 1);

            coins -= activeTrailCost;

            PlayerPrefs.SetInt("NumberOfCoins", coins);

            PlayerPrefs.SetString("EquiptedTrail", acitveTrailName);

            buyButton.SetActive(false);

            equipButton.SetActive(false);

            shop.coinsText.text = PlayerPrefs.GetInt("NumberOfCoins", 0).ToString();

        }

    }

    public void EquipTrail()
    {
        PlayerPrefs.SetString("EquiptedTrail", acitveTrailName);

        equipButton.SetActive(false);
    }

}
