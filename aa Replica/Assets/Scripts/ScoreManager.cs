using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private const string HighscoreKey = "Highscore";
    
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
}
