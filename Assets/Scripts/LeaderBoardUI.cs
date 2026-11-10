using UnityEngine;

public class LeaderBoardUI : MonoBehaviour
{
    [Header("Leaderboard UI")]
    public Transform content;
    public GameObject rowPrefab;

    // Called by the Refresh button.
    public void RefreshLeaderboard()
    {
        if (ChemistrologyLeaderboard.Instance == null)
        {
            Debug.LogError("Leaderboard manager was not found.");
            return;
        }

        ChemistrologyLeaderboard.Instance.GetTopScores(
            content,
            rowPrefab
        );
    }

    // Called by the Close button.
    public void CloseLeaderboard()
    {
        gameObject.SetActive(false);
    }

    // Called by the button that opens the leaderboard.
    public void OpenLeaderboard()
    {
        gameObject.SetActive(true);
        RefreshLeaderboard();
    }
}
