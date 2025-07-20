using UnityEngine;
using DG.Tweening;

public class GameStarter : MonoBehaviour
{
    [SerializeField] RectTransform topMenuBar;
    [SerializeField] float moveDuration;
    
    void Awake()
    {
        topMenuBar.anchoredPosition = new Vector2(topMenuBar.anchoredPosition.x, 245f);
        topMenuBar.DOAnchorPosY(0f, moveDuration).SetEase(Ease.InOutCubic);
        
        
    }
}
