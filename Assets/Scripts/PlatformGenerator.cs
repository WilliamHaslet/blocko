using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public Transform generationPoint;

	private float distanceBetween;

	private float platformWidth;

	public float distanceBetweenMin;

	public float distanceBetweenMax;

	private int platformSelector;

	private float[] platformWidths;

	public ObjectPooler[] theObjectPools;

	private float minHeight;

	public Transform maxHeightPoint;

	private float maxHeight;

	public float maxHeightChange;

	private float heightChange;

	private CoinGenerator theCoinGeneator;
    
	public float randomSpikeThreshold;

	public ObjectPooler spikePool;

	public float powerupHeight;

	public ObjectPooler coinPowerupPool;

	public ObjectPooler spikePowerupPool;

	public float doublePointsPowerupThreshold;

	public float noSpikesPowerupThreshold;

	public ObjectPooler[] theUnderPools;

	public float spikeHeightAbove;

	public float distanceBelow;

	public bool noSpikesPowerupOn;

	public bool doublePointsPowerupOn;

	public bool spikesActive;

    public bool canSpawnSpikes;

    private float powerupGenerationNumber;

    public int upsideDownPlatforms;

    private bool shouldSpawnUpsideDown, shouldSpawnRightSideUp;

    public Animator myAnimator;

    // Use this for initialization
    void Start () {

		platformWidths = new float[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++) {
		
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		
		}

		minHeight = transform.position.y;

		maxHeight = maxHeightPoint.position.y;

		theCoinGeneator = FindObjectOfType<CoinGenerator> ();

	}
	
	// Update is called once per frame
	void Update () {
        
		if (transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			platformSelector = Random.Range (0, theObjectPools.Length);

			powerupGenerationNumber = Random.Range (0f, 100f);

			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) {
			
				heightChange = maxHeight;
			
			} else if (heightChange < minHeight) {
			
				heightChange = minHeight;
			
			}

			if (powerupGenerationNumber < 50 && doublePointsPowerupOn && Random.Range (0f, 100f) < doublePointsPowerupThreshold) {
			
				GameObject newPowerup = coinPowerupPool.GetPooledObject ();

				newPowerup.transform.position = new Vector3 (transform.position.x + 4f, transform.position.y + (Random.Range (2f, powerupHeight)), 0);
			

				newPowerup.SetActive (true);

			}

			if (powerupGenerationNumber > 50 && noSpikesPowerupOn && Random.Range (0f, 100f) < noSpikesPowerupThreshold) {

				GameObject newPowerup = spikePowerupPool.GetPooledObject ();

				newPowerup.transform.position = new Vector3 (transform.position.x + 4f, transform.position.y + (Random.Range (2f, powerupHeight)), 0);

				newPowerup.SetActive (true);

			}

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 3) + distanceBetween, heightChange, 0);
            
            switch (upsideDownPlatforms)
            {

                case 1:

                    shouldSpawnUpsideDown = false;

                    shouldSpawnRightSideUp = true;

                    break;

                case 2:

                    shouldSpawnUpsideDown = true;

                    shouldSpawnRightSideUp = false;

                    upsideDownPlatforms = 3;

                    break;
                    
                case 3:

                    shouldSpawnUpsideDown = false;
                    
                    shouldSpawnRightSideUp = true;

                    upsideDownPlatforms = 2;

                    break;

                case 4:

                    shouldSpawnUpsideDown = true;
                    
                    shouldSpawnRightSideUp = true;

                    break;

                case 5:

                    shouldSpawnUpsideDown = true;

                    myAnimator.SetBool("flipped", true);

                    shouldSpawnRightSideUp = false;

                    break;

            }

            //Upside down platforms
            if (shouldSpawnUpsideDown)
            {
                GameObject newPlatform2 = theObjectPools[platformSelector].GetPooledObject();

                GameObject underPlatform2 = theUnderPools[platformSelector].GetPooledObject();

                newPlatform2.transform.position = new Vector2(transform.position.x, transform.position.y + distanceBelow);
                newPlatform2.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 180, 0);
                underPlatform2.transform.position = new Vector2(transform.position.x, transform.position.y + (distanceBelow * 2));
                underPlatform2.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 180, 0);

                newPlatform2.SetActive(true);

                underPlatform2.SetActive(true);

                theCoinGeneator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 3.6f, 0));

            }
            
            if (shouldSpawnRightSideUp)
            {

                GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

                GameObject underPlatform = theUnderPools[platformSelector].GetPooledObject();

                newPlatform.transform.position = transform.position;
                newPlatform.transform.rotation = transform.rotation;
                underPlatform.transform.position = new Vector3(transform.position.x, transform.position.y - distanceBelow, 0);
                underPlatform.transform.rotation = transform.rotation;

                newPlatform.SetActive(true);

                underPlatform.SetActive(true);

                theCoinGeneator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, 0));

            }
            
            switch (canSpawnSpikes) {

                case true:
                    canSpawnSpikes = false;
                    break;
                case false:
                    canSpawnSpikes = true;
                    break;
                default:
                    canSpawnSpikes = false;
                    break;
            }

			if (spikesActive && canSpawnSpikes && Random.Range (0f, 100f) < randomSpikeThreshold) {

				GameObject newSpike = spikePool.GetPooledObject ();

				Vector3 spikePosition = new Vector3 (Random.Range ((-platformWidths [platformSelector] / 2f) + 1f, (platformWidths [platformSelector] / 2f) - 1f), spikeHeightAbove, 0f);

				newSpike.transform.position = transform.position + spikePosition;

				newSpike.transform.rotation = transform.rotation;

				newSpike.SetActive (true);

			}

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 3), transform.position.y, -1f);

		}
		
	}

}
