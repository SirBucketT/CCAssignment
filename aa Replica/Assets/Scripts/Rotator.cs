using UnityEngine;

public class Rotator : MonoBehaviour {

	[SerializeField] float speed = 100f;

	void FixedUpdate ()
	{
		transform.Rotate(0f, 0f, speed * Time.deltaTime);
	}

}
