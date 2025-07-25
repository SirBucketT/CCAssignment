using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
    private const string HighscoreKey = "Highscore";
    
    [SerializeField] TextMeshProUGUI highscoreText, highscoreBackText;
    [SerializeField] SoundManager sound;

    void LateUpdate()
    {
        highscoreText.text = GetHighscore().ToString();
        highscoreBackText.text = highscoreText.text;
    }
    
    // Call this to update the highscore if the new score is higher
    public static void SetNewHighscore(int currentScore)
    {
        int storedHighscore = PlayerPrefs.GetInt(HighscoreKey);

        if (currentScore > storedHighscore)
        {
            PlayerPrefs.SetInt(HighscoreKey, currentScore); 
            PlayerPrefs.Save();
        }
    }

    // Call this to get the saved highscore
    public static int GetHighscore()
    {
        return PlayerPrefs.GetInt(HighscoreKey);
    }
    
    public void ResetHighscore()
    {
        sound.ClickSound();
        PlayerPrefs.DeleteKey(HighscoreKey);
    }
}
