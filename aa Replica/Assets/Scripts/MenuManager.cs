using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] RectTransform buttonTransform;
    
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
        // Shake the button
        buttonTransform.DOShakeAnchorPos(
            duration: 0.9f,     
            strength: 15f,      
            vibrato: 5,        
            randomness: 90f     
        ).OnComplete(() =>
        {
            SceneManager.LoadScene(0);
        });
    }
}
