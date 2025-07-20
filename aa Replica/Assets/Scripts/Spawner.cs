using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField] GameObject pinPrefab;

	void Update ()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			SpawnPin();
		}
	}

	void SpawnPin ()
	{
		Instantiate(pinPrefab, transform.position, transform.rotation);
	}

}
