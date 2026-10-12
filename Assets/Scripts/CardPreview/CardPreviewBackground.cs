
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CardPreviewBackground : MonoBehaviour
{
    [SerializeField] private float _fadeInOutDuration;
    [SerializeField] private float _alphaAmount;
    private Image _background;

    private void Awake()
    {
        _background = GetComponent<Image>();
    }
    public void EnableBackground(bool enabled)
    {
        if (enabled)
        {
            Color color = _background.color;
            color.a = _alphaAmount;
            _background.DOColor(color, _fadeInOutDuration);
        }
        else
        { 
            Color color = _background.color;
            color.a = 0;

            _background.DOColor(color, _fadeInOutDuration);
        }

    }
}