using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
            duration: 0.5f,     // how long the shake lasts
            strength: 10f,      // how far it moves
            vibrato: 10,        // how "fast" the shake is
            randomness: 90f     // how random the shake is
        )/*.OnComplete(() =>
        {
            SceneManager.LoadScene(0);
        })*/;
    }
}
