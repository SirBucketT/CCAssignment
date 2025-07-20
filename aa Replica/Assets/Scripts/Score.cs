using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Score : MonoBehaviour {

	public static int PinCount;

	[SerializeField] TexhMeshPro text; //uppgrade to textmesh pro

	void Start ()
	{
		PinCount = 0;
	}

	void FixedUpdate ()
	{
		text.text = PinCount.ToString();
	}

}
