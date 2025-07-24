using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int unlockedLevel;

    [SerializeField] int currentScore;
    [SerializeField] int scoreToUnlockNext;
    
    bool hasUnlocked;

    void Awake()
    {
        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        hasUnlocked = false;
    }
    
    void Update()
    {
        if (!hasUnlocked && currentScore >= scoreToUnlockNext)
        {
            UnlockNextLevel(unlockedLevel);
            hasUnlocked = true;
        }
    }

    void UnlockNextLevel(int levelJustCompleted)
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (levelJustCompleted >= unlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", levelJustCompleted + 1);
            PlayerPrefs.Save();
            Debug.Log("Unlocked Level: " + (levelJustCompleted + 1));
        }
    }
}
