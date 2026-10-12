using DG.Tweening;
using UnityEngine;

public class CardPreview : MonoBehaviour
{
    [SerializeField] private Vector3 _offsetRotationCard;

    [Header("Animation")]
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private Ease ease = Ease.OutCubic;

    [Header("Expanded")]
    [SerializeField] private Vector3 targetScale = Vector3.one * 5f;

    private Vector3 originalPosition;
    private Vector3 originalScale;
    private Quaternion originalRotation;

    private Tween moveTween;
    private Tween scaleTween;
    private Tween rotateTween;

    private Camera mainCam;

    private bool isExpanded;

    private CardPressEffect _cardPressEffect;

    public void InitializeCardPreview(Vector3 originalCardSize, CardPressEffect cardPressEffect)
    {
        transform.position = new Vector3(
             cardPressEffect.transform.position.x,
             cardPressEffect.transform.position.y,
             transform.position.z
         );

        RectTransform rect = cardPressEffect.GetComponent<RectTransform>();

        Vector3[] corners = new Vector3[4];
        rect.GetWorldCorners(corners);

        float width = Vector3.Distance(corners[0], corners[3]);
        float height = Vector3.Distance(corners[0], corners[1]);

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        Vector2 spriteSize = sr.sprite.bounds.size;

        transform.localScale = new Vector3(
            width / spriteSize.x,
            height / spriteSize.y,
            1f
        );

        _cardPressEffect = cardPressEffect;

        mainCam = Camera.main;

        originalPosition = transform.position;
        originalScale = transform.localScale;

        originalRotation = transform.rotation;

        ExpandCard();
    }

    [ContextMenu("ToggleCard")]
    public void ToggleCard()
    {
        if (isExpanded)
            CollapseCard();
        else
            ExpandCard();
    }

    /// <summary>
    /// Move sprite to center and scale up
    /// </summary>
    private void ExpandCard()
    {
        if (isExpanded)
            return;

        isExpanded = true;

        moveTween?.Kill();
        scaleTween?.Kill();
        rotateTween?.Kill();

        Vector3 centerScreen = mainCam.ViewportToWorldPoint(
            new Vector3(0.5f, 0.5f, GetDistanceFromCamera())
        );

        moveTween = transform.DOMove(centerScreen, duration)
            .SetEase(ease);

        Vector3 finalScale = Vector3.Scale(originalScale, targetScale);

        Sequence expandSequence = DOTween.Sequence();

        Vector3 overshootScale = finalScale * 1.08f;

        expandSequence.Append(
            transform.DOScale(overshootScale, duration * 0.8f)
                .SetEase(Ease.OutBack)
        );

        expandSequence.Append(
            transform.DOScale(finalScale, duration * 0.2f)
                .SetEase(Ease.OutQuad)
        );

        Quaternion targetRotation =
        originalRotation *
        Quaternion.Euler(_offsetRotationCard);

        rotateTween = transform.DORotateQuaternion(
            targetRotation,
            duration
        ).SetEase(ease);

        scaleTween = expandSequence;
    }

    /// <summary>
    /// Return sprite back to original position, size, and rotation
    /// </summary>
    private void CollapseCard()
    {
        if (!isExpanded)
            return;

        isExpanded = false;

        moveTween?.Kill();
        scaleTween?.Kill();
        rotateTween?.Kill();

        moveTween = transform.DOMove(originalPosition, duration)
            .SetEase(ease);

        Sequence collapseSequence = DOTween.Sequence();

        Vector3 undershootScale = originalScale * 0.92f;

        collapseSequence.Append(
            transform.DOScale(undershootScale, duration * 0.8f)
                .SetEase(Ease.InQuad)
        );

        collapseSequence.Append(
            transform.DOScale(originalScale, duration * 0.2f)
                .SetEase(Ease.OutBack)
        );

        // Tiny settle bounce at the END
        collapseSequence.Append(
            transform.DOScale(originalScale * 0.96f, 0.06f)
                .SetEase(Ease.OutQuad)
        );

        collapseSequence.Append(
            transform.DOScale(originalScale, 0.06f)
                .SetEase(Ease.InQuad)
        );

        scaleTween = collapseSequence;

        //
        // SMART ROTATION SNAP
        //
        // Keeps spinning direction continuous
        // Example:
        // 720 -> 680 instead of snapping to 0
        //

        Vector3 currentEuler = transform.eulerAngles;
        Vector3 targetEuler = originalRotation.eulerAngles;

        float targetY = GetClosestAngle(
            currentEuler.y,
            targetEuler.y
        );

        Vector3 finalEuler = new Vector3(
            targetEuler.x,
            targetY,
            targetEuler.z
        );

        rotateTween = transform.DORotate(
            finalEuler,
            duration,
            RotateMode.Fast
        ).SetEase(ease);

        _cardPressEffect.UnlockedCardUnpressEffect();
    }

    private float GetClosestAngle(float current, float target)
    {
        float delta = Mathf.DeltaAngle(current, target);

        return current + delta;
    }

    private float GetDistanceFromCamera()
    {
        return Mathf.Abs(
            transform.position.z - mainCam.transform.position.z
        );
    }
}