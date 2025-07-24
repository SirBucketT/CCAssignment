using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] RectTransform menuButtonFallingObject, creditsButtonFallingObject, levelsButtonFallingObject;
    [SerializeField] float moveDuration;
    [SerializeField] GameObject objectToHide;
    [SerializeField] GameObject textToHide;
    
    [SerializeField] SoundManager sounds;

    void Awake()
    {
        if (creditsButtonFallingObject != null)
        {
            creditsButtonFallingObject.anchoredPosition = new Vector2(creditsButtonFallingObject.anchoredPosition.x, 1984f);
        }

        if (levelsButtonFallingObject != null)
        {
            levelsButtonFallingObject.anchoredPosition = new Vector2(levelsButtonFallingObject.anchoredPosition.x, 1984f);
        }
    }
    
    public void LevelsButton()
    {
        sounds.ClickSound();
        if (creditsButtonFallingObject != null)
        {
            levelsButtonFallingObject.DOAnchorPosY(0f, moveDuration).SetEase(Ease.InOutCubic);
        }
    }
    
    public void CloseLevelsButton()
    {
        sounds.ClickSound();
        levelsButtonFallingObject.anchoredPosition = new Vector2(levelsButtonFallingObject.anchoredPosition.x, 0f);
        levelsButtonFallingObject.DOAnchorPosY(3026f, moveDuration).SetEase(Ease.InOutCubic);
    }
    
    public void CreditsButton()
    {
        sounds.ClickSound();
        if (creditsButtonFallingObject != null)
        {
            creditsButtonFallingObject.DOAnchorPosY(0f, moveDuration).SetEase(Ease.InOutCubic);
        }
    }

    public void CloseCreditsButton()
    {
        sounds.ClickSound();
        creditsButtonFallingObject.anchoredPosition = new Vector2(creditsButtonFallingObject.anchoredPosition.x, 0f);
        creditsButtonFallingObject.DOAnchorPosY(3026f, moveDuration).SetEase(Ease.InOutCubic);
    }
    
    public void QuitGame()
    {
        sounds.ClickSound();
        #if UNITY_EDITOR
           UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }

    public void PlayGame()
    {
        sounds.ClickSound();
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        //start falling image on press and on completes calls method to setActive(false) for all game objects and then switch to main menu scene
        sounds.ClickSound();
        menuButtonFallingObject.anchoredPosition = new Vector2(menuButtonFallingObject.anchoredPosition.x, 1996f);
        
        objectToHide.SetActive(false);
        textToHide.SetActive(false);
        menuButtonFallingObject.DOAnchorPosY(0f, moveDuration).SetEase(Ease.InOutCubic).OnComplete(() =>
        {
            menuButtonFallingObject.DOAnchorPosY(1996f, moveDuration).SetEase(Ease.InOutCubic).OnComplete(() =>
            {
                SceneManager.LoadScene(0);
            });
        });
    }
    
    public void OtherApps(string url)
    {
        sounds.ClickSound();
        Application.OpenURL(url);
    }
}
