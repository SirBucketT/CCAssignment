using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    int unlockedLevel;

    [SerializeField] int currentScore;
    [SerializeField] int scoreToUnlockNext;
    [SerializeField] int currentLevel;
    
    public Button[] levelButtons;
    
    bool hasUnlocked;

    void Start()
    {
        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        hasUnlocked = false;
        
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = (i + 1) <= unlockedLevel;
        }
    }
    
    void Update()
    {
        if (!hasUnlocked && currentScore >= scoreToUnlockNext)
        {
            UnlockNextLevel(currentLevel);
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
