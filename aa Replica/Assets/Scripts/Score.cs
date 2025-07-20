using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Score : MonoBehaviour {

	public static int PinCount;
	private int _highscore;

	[SerializeField] TextMeshProUGUI currentScoreText; //uppgrade to textmesh pro
	[SerializeField] TextMeshProUGUI highscoreText;

	void Awake ()
	{
		_highscore = ScoreManager.GetHighscore();
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
		}
	}

}
