using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SkinShopManager : MonoBehaviour {

    public TextMeshProUGUI activeSkinNameText, activeSkinCostText;

    public GameObject buyButton, equipButton;

    public string acitveSkinName;

    public int activeSkinCost;

    public Sprite[] skinImages;

    public Image skinModel;

    public ShopUI shop;

    public void ClickBlockoSkin()
    {
        acitveSkinName = "Blocko";
        activeSkinCost = 0;

        AcitvateButton();
    }

    public void ClickRedSkin()
    {
        acitveSkinName = "Red";
        activeSkinCost = 500;

        AcitvateButton();
    }

    public void ClickOrangeSkin()
    {
        acitveSkinName = "Orange";
        activeSkinCost = 500;

        AcitvateButton();
    }

    public void ClickYellowSkin()
    {
        acitveSkinName = "Yellow";
        activeSkinCost = 500;

        AcitvateButton();
    }

    public void ClickGreenSkin()
    {
        acitveSkinName = "Green";
        activeSkinCost = 500;

        AcitvateButton();
    }

    public void ClickCyanSkin()
    {
        acitveSkinName = "Cyan";
        activeSkinCost = 500;

        AcitvateButton();
    }

    public void ClickPurpleSkin()
    {
        acitveSkinName = "Purple";
        activeSkinCost = 500;

        AcitvateButton();
    }

    public void ClickPinkSkin()
    {
        acitveSkinName = "Pink";
        activeSkinCost = 500;

        AcitvateButton();
    }

    public void ClickWhiteSkin()
    {
        acitveSkinName = "White";
        activeSkinCost = 500;

        AcitvateButton();
    }

    public void ClickBlackSkin()
    {
        acitveSkinName = "Black";
        activeSkinCost = 500;

        AcitvateButton();
    }

    public void ClickFrownSkin()
    {
        acitveSkinName = "Frown";
        activeSkinCost = 1000;

        AcitvateButton();
    }

    public void ClickAmazedSkin()
    {
        acitveSkinName = "Amazed";
        activeSkinCost = 1000;

        AcitvateButton();
    }

    public void ClickSuprisedSkin()
    {
        acitveSkinName = "Surprised";
        activeSkinCost = 1000;

        AcitvateButton();
    }

    public void ClickSharkSkin()
    {
        acitveSkinName = "Shark";
        activeSkinCost = 1500;

        AcitvateButton();
    }

    public void ClickBorderlessSkin()
    {
        acitveSkinName = "Borderless";
        activeSkinCost = 1500;

        AcitvateButton();
    }

    public void ClickInvertedSkin()
    {
        acitveSkinName = "Inverted";
        activeSkinCost = 1500;

        AcitvateButton();
    }

    public void ClickClassicSkin()
    {
        acitveSkinName = "Classic";
        activeSkinCost = 1500;

        AcitvateButton();
    }

    public void ClickZebraSkin()
    {
        acitveSkinName = "Zebra";
        activeSkinCost = 2000;

        AcitvateButton();
    }

    public void ClickPolkaDotSkin()
    {
        acitveSkinName = "Polka Dot";
        activeSkinCost = 2000;

        AcitvateButton();
    }

    public void ClickRainbowSkin()
    {
        acitveSkinName = "Rainbow";
        activeSkinCost = 3000;

        AcitvateButton();
    }

    public void ClickCamouflageSkin()
    {
        acitveSkinName = "Camouflage";
        activeSkinCost = 3000;

        AcitvateButton();
    }

    public void ClickInvisibleSkin()
    {
        acitveSkinName = "Invisible";
        activeSkinCost = 5000;

        AcitvateButton();
    }

    public void ClickRobotSkin()
    {
        acitveSkinName = "Robot";
        activeSkinCost = 5000;

        AcitvateButton();
    }

    public void Click24KaratSkin()
    {
        acitveSkinName = "24 Karat";
        activeSkinCost = 10000;

        AcitvateButton();
    }

    public void AcitvateButton()
    {
        activeSkinNameText.text = acitveSkinName;
        activeSkinCostText.text = activeSkinCost.ToString();

        foreach (Sprite i in skinImages)
        {
            if (i.name == acitveSkinName)
            {
                skinModel.sprite = i;
            }
        }

        if (PlayerPrefs.GetInt(acitveSkinName + "Purchased") == 0)
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

    public void BuySkin()
    {

        int coins = PlayerPrefs.GetInt("NumberOfCoins", 0);

        if (coins < activeSkinCost)
        {

            shop.NotEnoughCoins();

        }
        else
        {
            PlayerPrefs.SetInt(acitveSkinName + "Purchased", 1);

            coins -= activeSkinCost;

            PlayerPrefs.SetInt("NumberOfCoins", coins);

            PlayerPrefs.SetString("EquiptedSkin", acitveSkinName);

            buyButton.SetActive(false);

            equipButton.SetActive(false);

            shop.coinsText.text = PlayerPrefs.GetInt("NumberOfCoins", 0).ToString();

        }

    }

    public void EquipSkin()
    {
        PlayerPrefs.SetString("EquiptedSkin", acitveSkinName);

        equipButton.SetActive(false);
    }

}
