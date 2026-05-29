using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardPressEffect : MonoBehaviour, IPointerClickHandler
{
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<Image>().material;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
