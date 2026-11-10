using System;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using UnityEngine;
public class ChemistrologyLeaderboard : MonoBehaviour
{
    // Must match the Leaderboard ID created in the Unity Dashboard.
    private const string LeaderboardId = "chemistrology_global";

    // Other scripts can check this before submitting a score.
    public bool IsReady { get; private set; }

    public static ChemistrologyLeaderboard Instance;


    private void Awake()
    {
        // Destroy duplicate managers if one already exists.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Store this manager as the persistent instance.
        Instance = this;

        // Keep this manager alive between scene changes.
        DontDestroyOnLoad(gameObject);
    }

    private async void Start()
    {
        try
        {
            // Initialize the Unity Gaming Services system.
            await UnityServices.InitializeAsync();

            // Sign in the player without requiring a manual login.
            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }

            IsReady = true;
            Debug.Log("Chemistrology leaderboard is ready.");
        }
        catch (Exception exception)
        {
            Debug.LogError("Leaderboard setup failed: " + exception.Message);
        }

        //leaderBoardUI =
    }


    public async void SubmitScore(int score)
    {
        // Do not send scores before the online service is ready.
        if (!IsReady)
        {
            Debug.LogWarning("Leaderboard is not ready yet.");
            return;
        }

        try
        {
            // Send this player's score to the online leaderboard.
            await LeaderboardsService.Instance.AddPlayerScoreAsync(
                LeaderboardId,
                score
            );

            Debug.Log("Score submitted: " + score);
        }
        catch (Exception exception)
        {
            Debug.LogError("Score submission failed: " + exception.Message);
        }


    }

    public async void GetTopScores(Transform content, GameObject rowPrefab)
    {
        // Check whether Unity Gaming Services is ready.
        if (!IsReady)
        {
            Debug.LogWarning("Leaderboard is not ready yet.");
            return;
        }

        // Make sure the UI references are assigned.
        if (content == null || rowPrefab == null)
        {
            Debug.LogError("Leaderboard Content or Row Prefab is missing.");
            return;
        }

        try
        {
            // Remove old rows before displaying refreshed results.
            foreach (Transform child in content)
            {
                Destroy(child.gameObject);
            }

            int offset = 0;
            int limit = 100;
            int totalDisplayed = 0;

            // Retrieve leaderboard entries in pages of 100.
            while (true)
            {
                var scores = await LeaderboardsService.Instance.GetScoresAsync(
                    LeaderboardId,
                    new GetScoresOptions
                    {
                        Offset = offset,
                        Limit = limit
                    }
                );

                // Stop if there are no more entries.
                if (scores.Results.Count == 0)
                {
                    break;
                }

                // Create one UI row for every leaderboard entry.
                foreach (var entry in scores.Results)
                {
                    GameObject newRow = Instantiate(rowPrefab, content);

                    LeaderBoardRowUI rowUI =
                        newRow.GetComponent<LeaderBoardRowUI>();

                    if (rowUI == null)
                    {
                        Debug.LogError("LeaderboardRowUI is missing on the row prefab.");
                        Destroy(newRow);
                        continue;
                    }

                    // Use a fallback name if the player has no display name.
                    string playerName = string.IsNullOrEmpty(entry.PlayerName)
                        ? "Anonymous"
                        : entry.PlayerName;

                    rowUI.SetData(
                        entry.Rank.ToString(),
                        playerName,
                        entry.Score.ToString("N0")
                    );

                    totalDisplayed++;
                }

                // If fewer than 100 entries were returned, this was the last page.
                if (scores.Results.Count < limit)
                {
                    break;
                }

                // Move to the next page.
                offset += limit;
            }

            Debug.Log("Leaderboard entries displayed: " + totalDisplayed);
        }
        catch (System.Exception exception)
        {
            Debug.LogError("Could not retrieve leaderboard: " + exception.Message);
        }
    }

    public async Task<string> SetPlayerNicknameAsync(string nickname)
    {
        if (!IsReady)
        {
            throw new System.Exception("Leaderboard is not ready.");
        }

        nickname = nickname.Trim();

        // Reject empty names and names containing whitespace.
        if (string.IsNullOrWhiteSpace(nickname) ||
            nickname.Length > 50 ||
            nickname.Contains(" "))
        {
            throw new System.Exception(
                "Enter a nickname without spaces (maximum 50 characters)."
            );
        }

        // Send the nickname to Unity Authentication.
        string updatedName =
            await AuthenticationService.Instance.UpdatePlayerNameAsync(nickname);

        Debug.Log("Player nickname saved: " + updatedName);

        // Return the actual name assigned by Unity.
        return updatedName;
    }

    // Temporary test method to submit a score of 500.
    public void TestSubmitScore()
    {
        SubmitScore(500);
    }

    // Temporary test method to retrieve the top scores.
    public void TestLoadScores()
    {
        //GetTopScores(leaderBoardUI.content,
        //leaderBoardUI.rowPrefab);
        Debug.Log("Score Fetched");
    }
}
