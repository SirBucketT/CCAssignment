using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] RectTransform buttonTransform;
    [SerializeField] RectTransform fallingObject;
    
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
