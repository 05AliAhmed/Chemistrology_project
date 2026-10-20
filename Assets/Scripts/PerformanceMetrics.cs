using System.Collections.Generic;
using UnityEngine;

public class PerformanceMetrics : MonoBehaviour
{
    // Store the duration of each frame in milliseconds.
    private readonly List<float> frameTimes = new List<float>();

    private bool recording = false;
    public static PerformanceMetrics instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F8))
        {
            if (!recording)
            {
                frameTimes.Clear();
                recording = true;
                Debug.Log("Performance recording started.");
            }
            else
            {
                recording = false;
                CalculateResults();
            }

            return;
        }

        if (recording)
        {
            // Record frame duration without time-scale effects.
            frameTimes.Add(Time.unscaledDeltaTime * 1000f);
        }
    }

    void CalculateResults()
    {
        if (frameTimes.Count < 100)
        {
            Debug.Log("Record more frames before calculating.");
            return;
        }

        // Sort frame times from fastest to slowest.
        List<float> sorted = new List<float>(frameTimes);
        sorted.Sort();

        // The 99th percentile frame time represents the
        // slowest 1% boundary.
        int index = Mathf.Clamp(
            Mathf.CeilToInt(sorted.Count * 0.99f) - 1,
            0,
            sorted.Count - 1
        );

        float percentileFrameTime = sorted[index];

        // Convert the 99th percentile frame time to FPS.
        float onePercentLow = 1000f / percentileFrameTime;

        // Calculate the average FPS across the recording.
        float totalSeconds = 0f;
        foreach (float ms in frameTimes)
        {
            totalSeconds += ms / 1000f;
        }

        float averageFPS = frameTimes.Count / totalSeconds;

        Debug.Log($"Frames recorded: {frameTimes.Count}");
        Debug.Log($"Average FPS: {averageFPS:F2}");
        Debug.Log($"1% low FPS: {onePercentLow:F2}");
        Debug.Log($"Slowest 1% boundary: {percentileFrameTime:F2} ms");
    }
}
