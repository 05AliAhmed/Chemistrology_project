using UnityEngine;
using TMPro;
using System;
using System.Threading.Tasks;

public class NickNameInputUI : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField nicknameInputField;
    public TMP_Text statusText;
    public GameObject nicknamePanel;

    private async void Start()
    {
        // Wait until Unity Gaming Services is initialized and the player is signed in.
        while (ChemistrologyLeaderboard.Instance == null ||
               !ChemistrologyLeaderboard.Instance.IsReady)
        {
            await System.Threading.Tasks.Task.Yield();
        }

        //try
        //{
        //    // Check whether this player already has a nickname.
        //    string existingName =
        //        await Unity.Services.Authentication.AuthenticationService
        //            .Instance.GetPlayerNameAsync(autoGenerate: false);

        //    if (!string.IsNullOrEmpty(existingName))
        //    {
        //        // A nickname already exists, so hide the nickname panel.
        //        nicknamePanel.SetActive(false);
        //    }
        //    else
        //    {
        //        // No nickname exists, so ask the player to enter one.
        //        nicknamePanel.SetActive(true);
        //    }
        //}
        //catch (System.Exception exception)
        //{
        //    // If checking the nickname fails, show the input panel.
        //    Debug.LogError("Could not check player nickname: " + exception.Message);
        //    nicknamePanel.SetActive(true);
        //}
    }


    // Called when the player clicks the Submit button.
    public async void OnSubmitNickname()
    {
        nicknamePanel.SetActive(false);
        string nickname = nicknameInputField.text.Trim();

        // Check whether the player entered a nickname.
        if (string.IsNullOrWhiteSpace(nickname))
        {
            statusText.text = "Please enter a nickname.";
            return;
        }

        // Check whether the leaderboard manager exists.
        if (ChemistrologyLeaderboard.Instance == null)
        {
            statusText.text = "Leaderboard manager not found.";
            return;
        }

        // Check whether Unity Gaming Services is ready.
        if (!ChemistrologyLeaderboard.Instance.IsReady)
        {
            statusText.text = "Please wait. Connecting to server...";
            return;
        }

        // Prevent the player from submitting multiple times.
        statusText.text = "Saving nickname...";

        try
        {
            // Save the nickname using the leaderboard manager.
            string savedName = await
                ChemistrologyLeaderboard.Instance.SetPlayerNicknameAsync(nickname);

            // Display the name returned by Unity.
            statusText.text = "Welcome, " + savedName + "!";

            Debug.Log("Nickname successfully registered: " + savedName);

            // Hide the nickname panel after successful registration.
            nicknamePanel.SetActive(false);
        }
        catch (Exception exception)
        {
            // Display an error if the nickname could not be saved.
            statusText.text = "Could not save nickname. Try again.";

            Debug.LogError("Nickname error: " + exception.Message);
        }
    }
}
