using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private const string HighscoreKey = "Highscore";
    
    //I know this should be managed else where, but I'm lazy
    [SerializeField] TextMeshProUGUI HighscoreText;

    void Start()
    {
        HighscoreText.text = GetHighscore().ToString();
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
        PlayerPrefs.DeleteKey(HighscoreKey);
    }
}
