using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    public Button[] levelButtons;
    [SerializeField] SoundManager sounds;

    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        

        for (int i = 0; i < levelButtons.Length; i++)
        {
            bool isUnlocked = (i + 1) <= unlockedLevel;
            Debug.Log($"Level {i + 1}: Unlocked = {isUnlocked}");

            if (levelButtons[i] != null)
            {
                levelButtons[i].interactable = isUnlocked;
            }
        }
    }
    
    public void PlayLevelOne()
    {
        sounds.ClickSound();
        SceneManager.LoadScene(1);
    }
    
    public void PlayLeveltwo()
    {
        sounds.ClickSound();
        SceneManager.LoadScene(2);
    }
}