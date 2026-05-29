using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardPressEffect : MonoBehaviour, IPointerClickHandler
{
    private static event Action<CardPressEffect> OnPress;
    private static event Action<bool> OnPressAllowed;

    [SerializeField] private bool _lockedCard;
    [SerializeField] private float _pressedDuration = 0.12f;
    [SerializeField] private float _transitionTime = 0.15f;
    [SerializeField] private Vector2 _startAnimationTime;
    [SerializeField] private CardPreviewBackground _previewBackground;

    [Header("Scale")]
    [SerializeField] private float _pressScaleMultiplier = 1.25f;

    [Header("Unlocked Cards")]
    [SerializeField] private CardPreview _cardPf;
    [SerializeField] private float _waitDurationBeforeEnableLockedCards;

    private Material _material;
    private Sequence _sequence;
    private Animator _animator;
    private Image _image;

    private Vector3 _originalScale;
    private bool _pressActivated;
    private bool _pressAllowed = true;
    private CardPreview _cardPreview;

    private void Awake()
    {
        _material = GetComponent<Image>().material;
        _animator = GetComponent<Animator>();
        _image = GetComponent<Image>();

        _originalScale = transform.localScale;
    }

    private void OnEnable()
    {
        OnPress += OnCardPressed;
        OnPressAllowed += OnTogglePressAllowed;
    }

    private void OnDisable()
    {
        OnPress -= OnCardPressed;
        OnPressAllowed -= OnTogglePressAllowed;

    }

    private void OnTogglePressAllowed(bool enabled)
    {
        _pressAllowed = enabled;
    }

    private void OnCardPressed(CardPressEffect effect)
    {
        if (!_pressAllowed) return;

        if (effect == this)
        {
            CardPressEffectPlay();
        }
        else
        {
            CardPressEffectStop();
        }
    }

    private void Start()
    {
        _material.SetFloat("_pressed", 0);

        float playbackTime = UnityEngine.Random.Range(_startAnimationTime.x, _startAnimationTime.y);

        // Get current state's hash
        int stateHash = _animator.GetCurrentAnimatorStateInfo(0).shortNameHash;

        // Play current animation at random time
        _animator.Play(stateHash, 0, playbackTime);

        // Force update immediately
        _animator.Update(0);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        OnPress?.Invoke(this);
    }

    private void CardPressEffectPlay()
    {
        _pressActivated = true;

        if (_lockedCard) // Unlocked cards will be pressed, bigized and then stay that way until click other place
        {
            LockedCardPressEffect();
        }
        else // Locked cards will be pressed (darkened), bigized and then return to normal after duration
        {
            UnlockedCardPressEffect();   
        }
    }

    private void CardPressEffectStop()
    {
        _pressActivated = false;

        if (_lockedCard)
        {
            LockedCardUnpressEffect();
        }
        else
        {
            UnlockedCardUnpressEffect();
        }
    }

    #region Locked Cards
    private void LockedCardUnpressEffect()
    {
        // Stop previous animation
        _sequence?.Kill();

        transform.DOKill();

        _sequence = DOTween.Sequence();

        // Shader OFF
        _sequence.Append(
            _material.DOFloat(0f, "_pressed", _transitionTime)
        );

        // Scale back to normal
        _sequence.Join(
            transform.DOScale(
                _originalScale,
                _transitionTime
            ).SetEase(Ease.OutQuad)
        );
    }

    private void LockedCardPressEffect()
    {
        // Stop previous animation
        _sequence?.Kill();

        transform.DOKill();

        _sequence = DOTween.Sequence();

        // Press shader ON
        _sequence.Append(
            _material.DOFloat(1f, "_pressed", _transitionTime)
        );

        // Scale UP
        _sequence.Join(
            transform.DOScale(
                _originalScale * _pressScaleMultiplier,
                _transitionTime
            ).SetEase(Ease.OutBack)
        );

        // Shader OFF
        _sequence.Append(
            _material.DOFloat(0f, "_pressed", _transitionTime)
        );

        // Scale back to normal
        _sequence.Join(
            transform.DOScale(
                _originalScale,
                _transitionTime
            ).SetEase(Ease.OutQuad)
        );
    }

    #endregion

    #region Unlocked Cards

    public void UnlockedCardUnpressEffect()
    {
        StartCoroutine(ResetUnlockedCards());

    }

    private void UnlockedCardPressEffect()
    {
        _image.enabled = false;
        OnPressAllowed?.Invoke(false);
        _cardPreview = Instantiate(_cardPf);
        _cardPreview.InitializeCardPreview(_originalScale, this);
        _previewBackground.EnableBackground(true);
    }

    private IEnumerator ResetUnlockedCards()
    {
        _previewBackground.EnableBackground(false);

        yield return new WaitForSeconds(_waitDurationBeforeEnableLockedCards);

        _image.enabled = true;
        OnPress?.Invoke(null);
        OnPressAllowed?.Invoke(true);
        Destroy(_cardPreview.gameObject);

    }

    #endregion
}
