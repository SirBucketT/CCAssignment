using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int unlockedLevel;

    private int currentScore;
    [SerializeField] int scoreToUnlockNext;
    [SerializeField] TextMeshProUGUI levelUnlockedText;
    
    bool hasUnlocked;

    void Awake()
    {
        PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel);
        PlayerPrefs.Save();
        hasUnlocked = false;
    }
    
    void Update()
    {
       currentScore = Score.PinCount;
        if (!hasUnlocked && currentScore >= scoreToUnlockNext)
        {
            UnlockNextLevel(unlockedLevel);
            levelUnlockedText.transform.DOScale(1f, 0.5f).SetEase(Ease.InOutCubic).
                OnComplete(() =>
                {
                    levelUnlockedText.transform.DOScale(0f, 0.5f).SetEase(Ease.InOutCubic);
                });
            
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
