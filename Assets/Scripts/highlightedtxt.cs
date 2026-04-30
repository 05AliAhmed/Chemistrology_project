using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class highlightedtxt : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Button lvlbutton;
    TMP_Text btnText;
    Color btnOriginalColor;

    void Awake()
    {
        lvlbutton = GetComponent<Button>();
        btnText = GetComponentInChildren<TMP_Text>();
        btnOriginalColor = btnText.color;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        btnText.color = lvlbutton.colors.pressedColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        btnText.color = btnOriginalColor;
    }

}
