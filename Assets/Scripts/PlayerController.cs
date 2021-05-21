using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D myRigidBody;

    public float moveSpeed, speedShouldIncreasePoint, increaseRate;

    private float moveSpeedStore, speedShouldIncreasePointStore;
    
    public float jumpForce, jumpTime, jumpTimeCounter;

    public int numberOfJumps;

    public bool grounded, canDoubleJump, doubleJumpOn, hasJumped, iceUpOrDown, canInfiniteJump;
    
    public LayerMask whatIsGround;

    public Transform groundCheckOne, groundCheckTwo;
    
    public float groundCheckRadius;

    public Animator myAnimator;

    public GameplayManager gameManager;

    public ScoreManager scoreManager;

    public PowerupManager powerupManager;

    public AudioSource jumpSound, deathSound;
    
    private GameObject hat;

    public SpriteRenderer skin;

    public Sprite[] skins;

    public GameObject[] hats;

    public GameObject[] trails;

    public GameObject[] particles;

    public bool flipped;

    public bool cancelJump;

    public bool buttonDown;
    
    void Start()
    {

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

        jumpTimeCounter = jumpTime;
        
        moveSpeedStore = moveSpeed;

        speedShouldIncreasePointStore = speedShouldIncreasePoint;
        
        for (int i = 0; i < hats.Length; i++)
        {

            if (hats[i].name == (PlayerPrefs.GetString("EquiptedHat", "None")))
            {

                hats[i].SetActive(true);

            }

        }

        for (int i = 0; i < trails.Length; i++)
        {

            if (trails[i].name == (PlayerPrefs.GetString("EquiptedTrail", "None")))
            {

                trails[i].SetActive(true);

            }

        }

        for (int i = 0; i < particles.Length; i++)
        {

            if (particles[i].name == (PlayerPrefs.GetString("EquiptedParticle", "None")))
            {

                particles[i].SetActive(true);

            }

        }

        for (int i = 0; i < skins.Length; i++)
        {

            if (skins[i].name == (PlayerPrefs.GetString("EquiptedSkin", "Blocko")))
            {

                skin.sprite = skins[i];

            }

        }
        
    }

    void Update()
    {
        
        grounded = Physics2D.OverlapCircle(groundCheckOne.position, groundCheckRadius, whatIsGround) || Physics2D.OverlapCircle(groundCheckTwo.position, groundCheckRadius, whatIsGround);

        if (grounded)
        {

            if (doubleJumpOn)
            {

                canDoubleJump = true;

            }

            hasJumped = false;

            jumpTimeCounter = jumpTime;

        }

        myAnimator.SetBool("grounded", grounded);

        if (scoreManager.scoreCount > speedShouldIncreasePoint)
        {

            if (scoreManager.highScoreKey == "Sprint2Highscore")
            {

                moveSpeed = moveSpeedStore;
                
                switch (iceUpOrDown) {

                    case true:

                        iceUpOrDown = false;

                        moveSpeed *= Random.Range(1.3f, 1.5f);

                        break;

                    case false:
                        
                        iceUpOrDown = true;

                        moveSpeed *= Random.Range(0.6f, 0.9f);

                        break;

                }

                speedShouldIncreasePoint += Random.Range(5, 20);
                
            }
            else
            {

                speedShouldIncreasePoint *= 2;

                moveSpeed *= increaseRate;

                scoreManager.pointsPerSecond *= increaseRate;

                powerupManager.currentPointsPerSecond *= increaseRate;

            }

        }
        
        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

        if (buttonDown)
        {

            if (jumpTimeCounter > 0)
            {

                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);

                jumpTimeCounter -= Time.deltaTime;

            }
            else
            {

                buttonDown = false;

            }

        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Killbox")
        {
            
            deathSound.Play();
            
            int currentJumps = PlayerPrefs.GetInt("NumberOfJumps", 0);
            
            PlayerPrefs.SetInt("NumberOfJumps", currentJumps + numberOfJumps);

            numberOfJumps = 0;

            gameManager.EndGame();

            moveSpeed = moveSpeedStore;

            speedShouldIncreasePoint = speedShouldIncreasePointStore;

            powerupManager.currentPointsPerSecond = scoreManager.pointsPerSecondStore;

            myRigidBody.transform.rotation = new Quaternion(0, 0, 0, 0);

            grounded = true;

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
            });

            switch (scoreManager.highScoreKey)
            {

                case "EasyHighscore":

                    new GameSparks.Api.Requests.LogEventRequest()
                    .SetEventKey("SUBMIT_EASY")
                    .SetEventAttribute("EASY_SCORE", scoreManager.scoreCount.ToString("0"))
                    .Send((response) =>
                    {

                        if (!response.HasErrors)
                        {
                            Debug.Log("Easy Score Posted Successfully...");
                        }
                        else
                        {
                            Debug.Log("Easy Error Posting Score...");
                        }

                    });

                    if (scoreManager.isHighscore == true)
                    {

                        new GameSparks.Api.Requests.LogEventRequest()
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

                    }

                    break;

                case "NormalHighscore":

                    new GameSparks.Api.Requests.LogEventRequest()
                    .SetEventKey("SUBMIT_NORMAL")
                    .SetEventAttribute("NORMAL_SCORE", scoreManager.scoreCount.ToString("0"))
                    .Send((response) =>
                    {

                        if (!response.HasErrors)
                        {
                            Debug.Log("Normal Score Posted Successfully...");
                        }
                        else
                        {
                            Debug.Log("Normal Error Posting Score...");
                        }

                    });

                    if (scoreManager.isHighscore == true)
                    {

                        new GameSparks.Api.Requests.LogEventRequest()
                        .SetEventKey("SUBMIT_NORMAL_AT")
                        .SetEventAttribute("NORMAL_SCORE_AT", PlayerPrefs.GetFloat("NormalHighscore", 0f).ToString("0"))
                        .Send((response) =>
                        {

                            if (!response.HasErrors)
                            {
                                Debug.Log("NOrmal AT Score Posted Successfully...");
                            }
                            else
                            {
                                Debug.Log("Normal AT Error Posting Score...");
                            }

                        });

                    }

                    break;

                case "SpikesHighscore":

                    new GameSparks.Api.Requests.LogEventRequest()
                    .SetEventKey("SUBMIT_SPIKES")
                    .SetEventAttribute("SPIKES_SCORE", scoreManager.scoreCount.ToString("0"))
                    .Send((response) =>
                    {

                        if (!response.HasErrors)
                        {
                            Debug.Log("Spikes Score Posted Successfully...");
                        }
                        else
                        {
                            Debug.Log("Spikes Error Posting Score...");
                        }

                    });

                    if (scoreManager.isHighscore == true)
                    {

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

                    }

                    break;

                case "HardHighscore":

                    new GameSparks.Api.Requests.LogEventRequest()
                    .SetEventKey("SUBMIT_HARD")
                    .SetEventAttribute("HARD_SCORE", scoreManager.scoreCount.ToString("0"))
                    .Send((response) =>
                    {

                        if (!response.HasErrors)
                        {
                            Debug.Log("Hard Score Posted Successfully...");
                        }
                        else
                        {
                            Debug.Log("Hard Error Posting Score...");
                        }

                    });

                    if (scoreManager.isHighscore == true)
                    {

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

                    }

                    break;

                case "IntenseHighscore":

                    new GameSparks.Api.Requests.LogEventRequest()
                    .SetEventKey("SUBMIT_INTENSE")
                    .SetEventAttribute("INTENSE_SCORE", scoreManager.scoreCount.ToString("0"))
                    .Send((response) =>
                    {

                        if (!response.HasErrors)
                        {
                            Debug.Log("Intense Score Posted Successfully...");
                        }
                        else
                        {
                            Debug.Log("Intense Error Posting Score...");
                        }

                    });

                    if (scoreManager.isHighscore == true)
                    {

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

                    }

                    break;

                case "InsaneHighscore":

                    new GameSparks.Api.Requests.LogEventRequest()
                    .SetEventKey("SUBMIT_INSANE")
                    .SetEventAttribute("INSANE_SCORE", scoreManager.scoreCount.ToString("0"))
                    .Send((response) =>
                    {

                        if (!response.HasErrors)
                        {
                            Debug.Log("Insane Score Posted Successfully...");
                        }
                        else
                        {
                            Debug.Log("Insane Error Posting Score...");
                        }

                    });

                    if (scoreManager.isHighscore == true)
                    {

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

                    }

                    break;

                case "FlippedHighscore":

                    new GameSparks.Api.Requests.LogEventRequest()
                    .SetEventKey("SUBMIT_FLIPPED")
                    .SetEventAttribute("FLIPPED_SCORE", scoreManager.scoreCount.ToString("0"))
                    .Send((response) =>
                    {

                        if (!response.HasErrors)
                        {
                            Debug.Log("Flipped Score Posted Successfully...");
                        }
                        else
                        {
                            Debug.Log("Flipped Error Posting Score...");
                        }

                    });

                    if (scoreManager.isHighscore == true)
                    {

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

                    }

                    break;

                case "Sprint2Highscore":

                    new GameSparks.Api.Requests.LogEventRequest()
                    .SetEventKey("SUBMIT_SPRINT")
                    .SetEventAttribute("SPRINT_SCORE", scoreManager.scoreCount.ToString("0"))
                    .Send((response) =>
                    {

                        if (!response.HasErrors)
                        {
                            Debug.Log("Sprint Score Posted Successfully...");
                        }
                        else
                        {
                            Debug.Log("Sprint Error Posting Score...");
                        }

                    });

                    if (scoreManager.isHighscore == true)
                    {

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

                    }

                    break;

                case "FlightHighscore":

                    new GameSparks.Api.Requests.LogEventRequest()
                    .SetEventKey("SUBMIT_FLIGHT")
                    .SetEventAttribute("FLIGHT_SCORE", scoreManager.scoreCount.ToString("0"))
                    .Send((response) =>
                    {

                        if (!response.HasErrors)
                        {
                            Debug.Log("Flight Score Posted Successfully...");
                        }
                        else
                        {
                            Debug.Log("Flight Error Posting Score...");
                        }

                    });

                    if (scoreManager.isHighscore == true)
                    {

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

                    }

                    break;

                case "SpaceHighscore":

                    new GameSparks.Api.Requests.LogEventRequest()
                    .SetEventKey("SUBMIT_SPACE")
                    .SetEventAttribute("SPACE_SCORE", scoreManager.scoreCount.ToString("0"))
                    .Send((response) =>
                    {

                        if (!response.HasErrors)
                        {
                            Debug.Log("Space Score Posted Successfully...");
                        }
                        else
                        {
                            Debug.Log("Space Error Posting Score...");
                        }

                    });

                    if (scoreManager.isHighscore == true)
                    {

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

                    }

                    break;

                case "MoonHighscore":

                    new GameSparks.Api.Requests.LogEventRequest()
                    .SetEventKey("SUBMIT_MOON")
                    .SetEventAttribute("MOON_SCORE", scoreManager.scoreCount.ToString("0"))
                    .Send((response) =>
                    {

                        if (!response.HasErrors)
                        {
                            Debug.Log("Moon Score Posted Successfully...");
                        }
                        else
                        {
                            Debug.Log("Moon Error Posting Score...");
                        }

                    });

                    if (scoreManager.isHighscore == true)
                    {

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

                    }

                    break;

                case "Gravity2Highscore":

                    new GameSparks.Api.Requests.LogEventRequest()
                    .SetEventKey("SUBMIT_GRAVITY")
                    .SetEventAttribute("GRAVITY_SCORE", scoreManager.scoreCount.ToString("0"))
                    .Send((response) =>
                    {

                        if (!response.HasErrors)
                        {
                            Debug.Log("Gravity Score Posted Successfully...");
                        }
                        else
                        {
                            Debug.Log("Gravity Error Posting Score...");
                        }

                    });

                    if (scoreManager.isHighscore == true)
                    {

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

                        });

                    }

                    break;

            }*/
            
        }
        
    }

    public void StartJump()
    {
        
        if ((grounded || !hasJumped || canInfiniteJump) && !cancelJump && !buttonDown)
        {

            if (scoreManager.highScoreKey == "Gravity2Highscore")
            {

                myRigidBody.gravityScale *= -1f;
                
                switch (flipped)
                {
                    case true:

                        myAnimator.SetBool("flipped", false);

                        flipped = false;

                        break;

                    case false:


                        myAnimator.SetBool("flipped", true);

                        flipped = true;

                        break;

                }

            }

            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
                
            buttonDown = true;

            jumpSound.Play();

            numberOfJumps++;

        }
        else if (!grounded && canDoubleJump && !cancelJump && !buttonDown)
        {

            if (scoreManager.highScoreKey == "Gravity2Highscore")
            {

                myRigidBody.gravityScale *= -1f;

                switch (flipped)
                {
                    case true:

                        myAnimator.SetBool("flipped", false);

                        flipped = false;

                        break;

                    case false:


                        myAnimator.SetBool("flipped", true);

                        flipped = true;

                        break;

                }

            }

            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            
            jumpTimeCounter = jumpTime;
            
            canDoubleJump = false;

            buttonDown = true;

            jumpSound.Play();

            numberOfJumps++;

        }

    }

    public void ReleaseJump()
    {

        jumpTimeCounter = 0;
        
        hasJumped = true;

        buttonDown = false;

    }

}
