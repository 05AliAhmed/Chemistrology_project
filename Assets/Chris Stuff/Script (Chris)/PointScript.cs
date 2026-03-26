using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PointScript : MonoBehaviour
{
    public Text totalPoint;
    int PlayerScore;
    public int gainPoint=100;
    public int losePoint=50;
    // Update is called once per frame
    


    public void EarnPoint()
    {
        PlayerScore = PlayerScore + gainPoint;
        totalPoint.text=PlayerScore.ToString();
    }

    public void LosePoint()
    {
        if (PlayerScore > 0)
        {
            PlayerScore = PlayerScore - losePoint;
            totalPoint.text = PlayerScore.ToString();
        }
        else if (PlayerScore <= 0)
        {
            totalPoint.text = "0";
        }
    }
}
