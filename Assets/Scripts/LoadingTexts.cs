using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingTexts : MonoBehaviour
{
    public TextMeshProUGUI UI;
    public TMP_Text uiText;
    public int number;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randnum();
        if (number == 0)
        {
            SetMessage("Sodium is so reactive with water that it can fizz, melt, and even burst into flame when dropped into it.");
        }
        else if (number == 1)
        {
            SetMessage("Magnesium burns with an intensely bright white flame and is used in flares and fireworks");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void randnum()
    {
       number= Random.Range(0, 2);
    }
    public void SetMessage(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            Debug.LogWarning("Attempted to set empty or null text.");
            message = ""; // Prevent null assignment
        }

        uiText.text = message;  // or uiText.SetText(message)
    }
}
