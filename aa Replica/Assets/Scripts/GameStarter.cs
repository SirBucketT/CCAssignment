using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class GameStarter : MonoBehaviour
{
    [SerializeField] RectTransform topMenuBar;
    [SerializeField] float moveDuration;

    [SerializeField] RectTransform menuButtons;
    
    void Awake()
    {
        topMenuBar.anchoredPosition = new Vector2(topMenuBar.anchoredPosition.x, 245f);
        topMenuBar.DOAnchorPosY(0f, moveDuration).SetEase(Ease.InOutCubic);
        
        menuButtons.position = new Vector3(0f, menuButtons.position.y, menuButtons.position.z);
        menuButtons.DOMoveX(200f, 1f).SetEase(Ease.InOutCubic);
    }
}
