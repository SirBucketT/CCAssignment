using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] RectTransform buttonTransform;
    [SerializeField] RectTransform fallingObject;
    [SerializeField] float moveDuration = 1f;
    
    public void QuitGame()
    {
        #if UNITY_EDITOR
           UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        buttonTransform.DOShakeAnchorPos(0.9f, strength: 15f, vibrato: 15, randomness: 90f)
            .OnComplete(() =>
            {
                fallingObject.anchoredPosition = new Vector2(fallingObject.anchoredPosition.x, 3026f);

                fallingObject.DOAnchorPosY(0f, moveDuration).SetEase(Ease.InOutCubic).OnComplete(() =>
                {
                    RemoveAllExceptCamera();
                    
                    SceneManager.LoadScene(0);
                });
            });
    }
    
    private void RemoveAllExceptCamera()
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.CompareTag("MainCamera") || obj == this.gameObject)
                continue;

            Destroy(obj);
        }
    }
}
