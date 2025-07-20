using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

	public static int PinCount;

	[SerializeField] TextMeshProUGUI coreText; //uppgrade to textmesh pro

	void Start ()
	{
		PinCount = 0;
	}

	//changed from void update to fixedupdate for performance reasons. 
	void FixedUpdate ()
	{
		coreText.text = PinCount.ToString();
	}

}
