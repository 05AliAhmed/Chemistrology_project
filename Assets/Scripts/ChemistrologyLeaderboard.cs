using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Leaderboards;

public class ChemistrologyLeaderboard : MonoBehaviour
{
    // Must match the Leaderboard ID created in the Unity Dashboard.
    private const string LeaderboardId = "chemistrology_global";

    // Other scripts can check this before submitting a score.
    public bool IsReady { get; private set; }

    public static ChemistrologyLeaderboard instance;

    private void Awake()
    {
        // Destroy duplicate managers if one already exists.
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Store this manager as the persistent instance.
        instance = this;

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

    public async void GetTopScores()
    {
        if (!IsReady)
        {
            Debug.LogWarning("Leaderboard is not ready yet.");
            return;
        }

        try
        {
            // Retrieve the top 10 entries by default

            var scores = await LeaderboardsService.Instance.GetScoresAsync(
            LeaderboardId,
            new GetScoresOptions { Limit = 10 }
            );

            // Print the retrieved entries in the Console for testing.
            foreach (var entry in scores.Results)
            {
                Debug.Log(
                    "Rank: " + entry.Rank +
                    " | Player ID: " + entry.PlayerId +
                    " | Score: " + entry.Score
                );
            }
        }
        catch (Exception exception)
        {
            Debug.LogError("Could not load scores: " + exception.Message);
        }
    }

    // Temporary test method to submit a score of 500.
    public void TestSubmitScore()
    {
        SubmitScore(500);
    }

    // Temporary test method to retrieve the top scores.
    public void TestLoadScores()
    {
        GetTopScores();
    }
}
