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
        //start falling image on press and on completes calls method to remove all objects except camera and then switch to main menu scene
        fallingObject.anchoredPosition = new Vector2(fallingObject.anchoredPosition.x, 3026f);

        fallingObject.DOAnchorPosY(0f, moveDuration).SetEase(Ease.InOutCubic).OnComplete(() =>
        {
            RemoveAllExceptCamera();
            
            SceneManager.LoadScene(0);
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
