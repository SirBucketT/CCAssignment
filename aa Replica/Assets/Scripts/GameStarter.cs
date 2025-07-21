using UnityEngine;
using DG.Tweening;

public class GameStarter : MonoBehaviour
{
    [SerializeField] RectTransform TopMenuBar;
    [SerializeField] float moveDuration;

    [SerializeField] RectTransform startButtons, resetScoreButton, quitGameButton, creditsButton;
    
    void Awake()
    {
        TopMenuBar.anchoredPosition = new Vector2(TopMenuBar.anchoredPosition.x, 245f);
        TopMenuBar.DOAnchorPosY(0f, moveDuration).SetEase(Ease.InOutCubic);
        
        startButtons.position = new Vector3( -459.45f, startButtons.position.y, startButtons.position.z);
        startButtons.DOMoveX(200f, moveDuration).SetEase(Ease.InOutCubic);
        
        resetScoreButton.position = new Vector3( -459.45f, resetScoreButton.position.y, resetScoreButton.position.z);
        resetScoreButton.DOMoveX(200f, moveDuration+0.2f).SetEase(Ease.InOutCubic);
        
        quitGameButton.position = new Vector3( -459.45f, quitGameButton.position.y, quitGameButton.position.z);
        quitGameButton.DOMoveX(200f, moveDuration+0.3f).SetEase(Ease.InOutCubic);
        
        creditsButton.position = new Vector3( -459.45f, creditsButton.position.y, creditsButton.position.z);
        creditsButton.DOMoveX(200f, moveDuration+0.4f).SetEase(Ease.InOutCubic);
    }
}
