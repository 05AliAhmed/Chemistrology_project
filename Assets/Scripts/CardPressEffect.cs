using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardPressEffect : MonoBehaviour, IPointerClickHandler
{
    private static event Action<CardPressEffect> OnPress;

    [SerializeField] private float _pressedDuration = 0.12f;
    [SerializeField] private float _transitionTime = 0.15f;

    [Header("Scale")]
    [SerializeField] private float _pressScaleMultiplier = 1.25f;

    private Material _material;
    private Sequence _sequence;
    private Animator _animator;

    private Vector3 _originalScale;

    private void Awake()
    {
        _material = GetComponent<Image>().material;
        _animator = GetComponent<Animator>();

        _originalScale = transform.localScale;
    }

    private void OnEnable()
    {
        OnPress += OnCardPressed;
    }

    private void OnDisable()
    {
        OnPress -= OnCardPressed;

    }

    private void OnCardPressed(CardPressEffect effect)
    {
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
        _animator.enabled = false;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        OnPress?.Invoke(this);
    }

    private void CardPressEffectPlay()
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

        // Pause while pressed
        _sequence.AppendInterval(_pressedDuration);

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

        _animator.enabled = true;
    }

    private void CardPressEffectStop()
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

        _animator.enabled = false;
    }
}
