
using DG.Tweening;
using UnityEngine;

public class CardWavingAnimation : MonoBehaviour
{
    [SerializeField] private float swayAmount = 15f;
    [SerializeField] private float swayDuration = 2f;

    private Vector2 startPos;

    private Tween swayTween;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

    }
    private void Start()
    {

        startPos = rectTransform.anchoredPosition;

        swayTween = rectTransform.DOAnchorPosY(
            startPos.y + swayAmount,
            swayDuration
        )
        .SetEase(Ease.InOutSine)
        .SetLoops(-1, LoopType.Yoyo)
        .SetUpdate(true);

        //
        // RANDOMIZE START POINT
        //

        float randomProgress = Random.Range(0f, 1f);

        swayTween.Goto(
            swayTween.Duration(false) * randomProgress,
            true
        );
    }

    private void OnDisable()
    {
        swayTween?.Kill();
    }
}