using System.Collections;
using System.IO;
using UnityEngine;

public class ScreenShotManager : MonoBehaviour
{
    public int width = 1200;
    public int height = 1920;
    public int numberOfScreenshots = 3;
    public float delayBetweenScreenshots = 1.0f;
    public string folderName = "Screenshots";

    private int currentIndex = 0;
    private bool isCapturing = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isCapturing)
        {
            StartCoroutine(CaptureMultipleScreenshots());
        }
    }

    IEnumerator CaptureMultipleScreenshots()
    {
        isCapturing = true;

#if UNITY_EDITOR
        // Resize the Game View window in the Editor to match portrait resolution
        UnityEditor.EditorWindow gameView = GetMainGameView();
        gameView.position = new Rect(gameView.position.x, gameView.position.y, width, height);
#endif

        string fullPath = Path.Combine(Application.dataPath, folderName);
        if (!Directory.Exists(fullPath))
        {
            Directory.CreateDirectory(fullPath);
        }

        while (currentIndex < numberOfScreenshots)
        {
            yield return new WaitForEndOfFrame();

            string filename = Path.Combine(fullPath, $"portrait_screenshot_{currentIndex + 1}.png");
            ScreenCapture.CaptureScreenshot(filename);
            Debug.Log($"📸 Saved: {filename}");

            currentIndex++;
            yield return new WaitForSeconds(delayBetweenScreenshots);
        }

        currentIndex = 0;
        isCapturing = false;
    }

#if UNITY_EDITOR
    UnityEditor.EditorWindow GetMainGameView()
    {
        System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
        System.Reflection.MethodInfo GetMainGameView = T.GetMethod("GetMainGameView", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        return (UnityEditor.EditorWindow)GetMainGameView.Invoke(null, null);
    }
#endif
}