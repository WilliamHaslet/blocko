using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialController : MonoBehaviour {

    public PlayerController playerController;

    public GameObject welcomeScreen;

    public GameObject clickContinue;

    public GameObject jumping;

    public GameObject howToJump;

    public GameObject doubleJump;

    public GameObject spinning;

    public GameObject score;

    public GameObject scoring;

    public GameObject leaderboards;

    public GameObject obstacles;

    public GameObject obstaclesExpilnation;

    public GameObject coins;

    public GameObject collectCoins;

    public GameObject powerups;

    public GameObject collectPowerups;

    public GameObject powerupsExpinations;

    public GameObject haveFun;

    public GameObject playAgain;
    
    // Use this for initialization
    void Start()
    {

        playerController.moveSpeed = 0;

    }

    public void Contiune()
    {

        if (clickContinue.activeInHierarchy == true)
        {

            welcomeScreen.SetActive(false);

            clickContinue.SetActive(false);

            jumping.SetActive(true);

            howToJump.SetActive(true);

        }
        else if (howToJump.activeInHierarchy == true)
        {

            howToJump.SetActive(false);

            doubleJump.SetActive(true);

            playerController.doubleJumpOn = true;

        }
        else if (doubleJump.activeInHierarchy == true)
        {

            playerController.doubleJumpOn = false;

            doubleJump.SetActive(false);

            spinning.SetActive(true);

        }
        else if (spinning.activeInHierarchy == true)
        {

            jumping.SetActive(false);

            spinning.SetActive(false);

            score.SetActive(true);

            scoring.SetActive(true);

        }
        else if (scoring.activeInHierarchy == true)
        {

            scoring.SetActive(false);

            leaderboards.SetActive(true);

        }
        else if (leaderboards.activeInHierarchy == true)
        {

            score.SetActive(false);

            leaderboards.SetActive(false);

            obstacles.SetActive(true);

            obstaclesExpilnation.SetActive(true);

        }
        else if (obstaclesExpilnation.activeInHierarchy == true)
        {

            obstacles.SetActive(false);

            obstaclesExpilnation.SetActive(false);

            coins.SetActive(true);

            collectCoins.SetActive(true);

        }
        else if (collectCoins.activeInHierarchy == true)
        {

            coins.SetActive(false);

            collectCoins.SetActive(false);

            powerups.SetActive(true);

            collectPowerups.SetActive(true);

        }
        else if (collectPowerups.activeInHierarchy == true)
        {

            collectPowerups.SetActive(false);

            powerupsExpinations.SetActive(true);

        }
        else if (powerupsExpinations.activeInHierarchy == true)
        {

            powerups.SetActive(false);

            powerupsExpinations.SetActive(false);

            haveFun.SetActive(true);

            playAgain.SetActive(true);

        }
        else if (playAgain.activeInHierarchy == true)
        {

            SceneManager.LoadScene("ModeMenu");

        }

    }

}
