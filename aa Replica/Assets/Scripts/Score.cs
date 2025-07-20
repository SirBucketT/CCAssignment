using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Score : MonoBehaviour {

	public static int PinCount;

	[SerializeField] TextMeshProUGUI text; //uppgrade to textmesh pro

	void Start ()
	{
		PinCount = 0;
	}

	void Update ()
	{
		text.text = PinCount.ToString();
	}

}
