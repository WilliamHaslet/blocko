using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

	public ObjectPooler coinPool;

	public float distanceBetweenCoinsMin;

	public float distanceBetweenCoinsMax;

	public float coinRandomOne;

	public float coinRandomTwo;

	public float coinRandomThree;

	public void SpawnCoins (Vector3 startPosition) {

		if (Random.Range (0f, 100f) < coinRandomOne) {
	
			GameObject coin1 = coinPool.GetPooledObject ();

			coin1.transform.position = startPosition;

			coin1.SetActive (true);

		}

		if (Random.Range (0f, 100f) < coinRandomTwo) {

			GameObject coin2 = coinPool.GetPooledObject ();

			coin2.transform.position = new Vector3 (startPosition.x - Random.Range (distanceBetweenCoinsMin, distanceBetweenCoinsMax), startPosition.y, startPosition.z);

			coin2.SetActive (true);

		}

		if (Random.Range (0f, 100f) < coinRandomThree) {

			GameObject coin3 = coinPool.GetPooledObject ();

			coin3.transform.position = new Vector3 (startPosition.x + Random.Range (distanceBetweenCoinsMin, distanceBetweenCoinsMax), startPosition.y, startPosition.z);
	
			coin3.SetActive (true);

		}
	
	}

}
