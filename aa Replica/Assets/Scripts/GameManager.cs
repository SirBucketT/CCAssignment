using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

	private int _highscore;
	private bool _gameHasEnded;

	[SerializeField] Rotator rotator;
	[SerializeField] Spawner spawner;

	[SerializeField] Animator animator;
	
	[SerializeField] TextMeshProUGUI scoreText;
	

	void Awake()
	{
		_gameHasEnded = false;
	}
	
	public void EndGame ()
	{
		if (_gameHasEnded)
			return;

		rotator.enabled = false;
		spawner.enabled = false;

		animator.SetTrigger("EndGame");

		_gameHasEnded = true;
	}

	public void RestartLevel ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
