using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] RectTransform menuButtonFallingObject, creditsButtonFallingObject;
    [SerializeField] float moveDuration = 1f;
    [SerializeField] GameObject objectToDestroy;
    
    public void CreditsButton()
    {
        creditsButtonFallingObject.anchoredPosition = new Vector2(creditsButtonFallingObject.anchoredPosition.x, 3026f);
        creditsButtonFallingObject.DOAnchorPosY(0f, moveDuration).SetEase(Ease.InOutCubic);
    }

    public void CloseCreditsButton()
    {
        creditsButtonFallingObject.anchoredPosition = new Vector2(creditsButtonFallingObject.anchoredPosition.x, 0f);
        creditsButtonFallingObject.DOAnchorPosY(3026f, moveDuration).SetEase(Ease.InOutCubic);
    }
    
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
        menuButtonFallingObject.anchoredPosition = new Vector2(menuButtonFallingObject.anchoredPosition.x, 3026f);

        // Move down to Y = 0
        menuButtonFallingObject.DOAnchorPosY(0f, moveDuration).SetEase(Ease.InOutCubic).OnComplete(() =>
        {
            // Move back up to Y = 3026
            menuButtonFallingObject.DOAnchorPosY(3026f, moveDuration).SetEase(Ease.InOutCubic).OnComplete(() =>
            {
                // Remove everything except camera
                RemoveAllExceptCamera();
                SceneManager.LoadScene(0);
            });
        });
    }
    
    private void RemoveAllExceptCamera()
    {
        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy);
        }
    }
    
    public void OtherApps(string url)
    {
        Application.OpenURL(url);
    }
}
