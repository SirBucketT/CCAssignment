using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] RectTransform menuButtonFallingObject, creditsButtonFallingObject;
    [SerializeField] float moveDuration;
    [SerializeField] GameObject objectToHide;
    
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
        //start falling image on press and on completes calls method to setActive(false) for all game objects and then switch to main menu scene
        menuButtonFallingObject.anchoredPosition = new Vector2(menuButtonFallingObject.anchoredPosition.x, 3026f);
        
        objectToHide.SetActive(false);
        menuButtonFallingObject.DOAnchorPosY(0f, moveDuration).SetEase(Ease.InOutCubic).OnComplete(() =>
        {
            menuButtonFallingObject.DOAnchorPosY(3026f, moveDuration).SetEase(Ease.InOutCubic).OnComplete(() =>
            {
                SceneManager.LoadScene(0);
            });
        });
    }
    
    public void OtherApps(string url)
    {
        Application.OpenURL(url);
    }
}
