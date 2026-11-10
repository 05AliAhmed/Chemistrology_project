using TMPro;
using UnityEngine;

public class LeaderBoardRowUI : MonoBehaviour
{
    // References to the three text objects in this row.
    public TMP_Text rankText;
    public TMP_Text playerNameText;
    public TMP_Text scoreText;

    // Updates the row with information from one player.
    public void SetData(string rank, string playerName, string score)
    {
        rankText.text = rank;
        playerNameText.text = playerName;
        scoreText.text = score;
    }
}
