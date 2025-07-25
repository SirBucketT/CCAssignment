using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

	public static int PinCount;
	private int _highscore;

	[SerializeField] TextMeshProUGUI currentScoreText; 
	
	void Awake ()
	{
		PinCount = 0;
	}

	//changed from void update to fixedupdate for performance reasons. 
	void FixedUpdate ()
	{
		currentScoreText.text = PinCount.ToString();
	}

	void Update()
	{
		if (PinCount >= ScoreManager.GetHighscore())
		{
			ScoreManager.SetNewHighscore(PinCount);
			_highscore = ScoreManager.GetHighscore();
		}
	}
}
