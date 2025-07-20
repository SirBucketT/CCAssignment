using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private bool gameHasEnded = false;

	[SerializeField] Rotator rotator;
	[SerializeField] Spawner spawner;

	[SerializeField] Animator animator;

	public void EndGame ()
	{
		if (gameHasEnded)
			return;

		rotator.enabled = false;
		spawner.enabled = false;

		animator.SetTrigger("EndGame");

		gameHasEnded = true;
	}

	public void RestartLevel ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
