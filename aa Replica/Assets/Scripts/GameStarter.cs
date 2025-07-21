/*  Game Starter is a script that runs at the start of the game 
 *  The main functionality of the Game Starter script is to initialize animations for each button featured on the main menu.
 *  It's also core to the animation of the top menu bar shown at the top of the screen that displays the current game highscore.
 * The script finally also animates the textmesh pro powered logo for the game.
 */

using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameStarter : MonoBehaviour
{
    [SerializeField] RectTransform topMenuBar;
    [SerializeField] float moveDuration;

    [SerializeField] RectTransform startButtons, resetScoreButton, quitGameButton, creditsButton;
    
    [SerializeField] GameObject logo;
    [SerializeField] float logoRotator;
    
    void Awake()
    {
        topMenuBar.anchoredPosition = new Vector2(topMenuBar.anchoredPosition.x, 245f);
        topMenuBar.DOAnchorPosY(-190f, moveDuration).SetEase(Ease.InOutCubic);
        
        startButtons.position = new Vector3( -459.45f, startButtons.position.y, startButtons.position.z);
        startButtons.DOMoveX(200f, moveDuration).SetEase(Ease.InOutCubic);
        
        resetScoreButton.position = new Vector3( -459.45f, resetScoreButton.position.y, resetScoreButton.position.z);
        resetScoreButton.DOMoveX(200f, moveDuration+0.2f).SetEase(Ease.InOutCubic);
        
        quitGameButton.position = new Vector3( -459.45f, quitGameButton.position.y, quitGameButton.position.z);
        quitGameButton.DOMoveX(200f, moveDuration+0.3f).SetEase(Ease.InOutCubic);
        
        creditsButton.position = new Vector3( -459.45f, creditsButton.position.y, creditsButton.position.z);
        creditsButton.DOMoveX(200f, moveDuration+0.4f).SetEase(Ease.InOutCubic);
        
        logo.transform.localScale = Vector3.zero;
        logo.gameObject.SetActive(true);
        logo.transform.DOScale(1f, 0.5f)
            .SetEase(Ease.OutBack)
            .OnComplete(() =>
            {
                logo.transform
                    .DORotate(new Vector3(0, 0, logoRotator), 1f)
                    .SetEase(Ease.InOutSine)
                    .SetLoops(-1, LoopType.Yoyo);
            });
    }
}
