using UnityEngine;

public class Pin : MonoBehaviour {

	private bool _isPinned;

	public float speed = 20f;
	public Rigidbody2D rb;

	void Start()
	{
		_isPinned = false;
	}
	
	void FixedUpdate ()
	{
		if (!_isPinned)
			rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Rotator")
		{
			transform.SetParent(col.transform);
			Score.PinCount++;
			_isPinned = true;
		} else if (col.tag == "Pin")
		{
			Object.FindFirstObjectByType<GameManager>().EndGame();
		}
	}
}
