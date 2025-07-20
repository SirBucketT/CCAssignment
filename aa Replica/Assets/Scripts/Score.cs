using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Score : MonoBehaviour {

	public static int PinCount;

	[SerializeField] TextMeshProUGUI coreText; //uppgrade to textmesh pro

	void Start ()
	{
		PinCount = 0;
	}

	void FixedUpdate ()
	{
		coreText.text = PinCount.ToString();
	}

}
