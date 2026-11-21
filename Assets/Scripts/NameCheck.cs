using System;
using Unity.Services.Authentication;
using UnityEngine;

public class NameCheck : MonoBehaviour
{
    // Assign NickNamePanel through the Inspector.
    public GameObject nicknamePanel;

    private async void Start()
    {
        // Wait until the persistent leaderboard manager exists
        // and authentication has finished initializing.
        float timeout = Time.time + 15f;

        while (ChemistrologyLeaderboard.Instance == null ||
               !ChemistrologyLeaderboard.Instance.IsReady)
        {
            // Prevent waiting forever if initialization fails.
            if (Time.time > timeout)
            {
                Debug.LogError("Timed out waiting for authentication.");

                nicknamePanel.SetActive(true);
                return;
            }

            // Wait for the next frame before checking again.
            await System.Threading.Tasks.Task.Yield();
        }

        try
        {
            // Retrieve the current player's existing nickname.
            string existingName = await AuthenticationService.Instance
                .GetPlayerNameAsync(autoGenerate: false);

            if (!string.IsNullOrEmpty(existingName))
            {
                // Player already has a nickname.
                nicknamePanel.SetActive(false);

                Debug.Log("Existing nickname found: " + existingName);
            }
            else
            {
                // Player has no nickname yet.
                nicknamePanel.SetActive(true);

                Debug.Log("No nickname found. Asking player to enter one.");
            }
        }
        catch (Exception exception)
        {
            Debug.LogError("Nickname check failed: " + exception.Message);

            // If the name check fails, show the panel.
            nicknamePanel.SetActive(true);
        }
    }
}
