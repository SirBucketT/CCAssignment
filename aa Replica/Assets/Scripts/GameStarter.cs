using UnityEngine;
using DG.Tweening;

public class GameStarter : MonoBehaviour
{
    [SerializeField] RectTransform topMenuBar;
    [SerializeField] float moveDuration;

    [SerializeField] RectTransform startButtons, resetScoreButton, quitGameButton;
    
    void Awake()
    {
        topMenuBar.anchoredPosition = new Vector2(topMenuBar.anchoredPosition.x, 245f);
        topMenuBar.DOAnchorPosY(0f, moveDuration).SetEase(Ease.InOutCubic);
        
        startButtons.position = new Vector3( -459.45f, startButtons.position.y, startButtons.position.z);
        startButtons.DOMoveX(200f, moveDuration).SetEase(Ease.InOutCubic);
        
        resetScoreButton.position = new Vector3( -459.45f, resetScoreButton.position.y, resetScoreButton.position.z);
        resetScoreButton.DOMoveX(200f, moveDuration+0.2f).SetEase(Ease.InOutCubic);
        
        quitGameButton.position = new Vector3( -459.45f, quitGameButton.position.y, quitGameButton.position.z);
        quitGameButton.DOMoveX(200f, moveDuration+0.3f).SetEase(Ease.InOutCubic);
    }
}
