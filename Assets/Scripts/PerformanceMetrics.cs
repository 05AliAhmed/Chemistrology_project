using System.Collections.Generic;
using UnityEngine;

public class PerformanceMetrics : MonoBehaviour
{
    // Stores each frame's duration in milliseconds.
    private readonly List<float> frameTimes = new List<float>();
    private bool recording = false;
    // Target frame rate used for the budget comparison.
    [SerializeField] private float targetFPS = 60f;
    public static PerformanceMetrics instance;
    void Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F8)){
            if (!recording){
                frameTimes.Clear();
                recording = true;
                Debug.Log("Performance recording started.");
            }
            else{
                recording = false;
                CalculateResults();
            }
            return;
        }
        // Record frame duration without time-scale effects.
        if (recording){ frameTimes.Add(Time.unscaledDeltaTime * 1000f);}
    }

    void CalculateResults()
    {
        int count = frameTimes.Count;
        if (count < 2){
            Debug.LogWarning("Not enough frames recorded.");
            return;
        }
        // Calculate total frame time in seconds.
        float totalSeconds = 0f;
        foreach (float time in frameTimes){ totalSeconds += time / 1000f;}
        // Average FPS is total frames divided by elapsed time.
        float averageFPS = count / totalSeconds;
        // Average duration of one frame, in milliseconds.
        float averageFrameTime = totalSeconds * 1000f / count;
        // Sort frame times to estimate the 1% low FPS.
        List<float> sortedTimes = new List<float>(frameTimes);
        sortedTimes.Sort();
        // The 99th percentile frame time represents the
        // boundary of the slowest 1% of frames.
        int index = Mathf.Clamp(
            Mathf.CeilToInt(count * 0.99f) - 1,
            0,
            count - 1
        );
        float percentileFrameTime = sortedTimes[index];
        float onePercentLowFPS = 1000f / percentileFrameTime;
        // Calculate average absolute difference between
        // consecutive frame times.
        float totalPacingDelta = 0f;
        for (int i = 1; i < count; i++){
            float delta = Mathf.Abs(
                frameTimes[i] - frameTimes[i - 1]
            );
            totalPacingDelta += delta;
        }
        float averageFramePacingDelta =
            totalPacingDelta / (count - 1);
        // Compare average frame time against the target budget.
        float targetFrameTime = 1000f / targetFPS;
        float frameBudgetDelta = averageFrameTime - targetFrameTime;

        // Print all performance metrics to the Unity Console.
        Debug.Log("===== PERFORMANCE RESULTS =====");
        Debug.Log($"Frames Recorded: {count}");
        Debug.Log($"Recording Duration: {totalSeconds:F2} seconds");
        Debug.Log($"Average FPS: {averageFPS:F2}");
        Debug.Log($"Average Frame Time: {averageFrameTime:F3} ms");
        Debug.Log($"1% Low FPS: {onePercentLowFPS:F2}");
        Debug.Log($"99th Percentile Frame Time: {percentileFrameTime:F3} ms");
        Debug.Log($"Average Frame Pacing Delta: {averageFramePacingDelta:F3} ms");
        Debug.Log($"Target Frame Time: {targetFrameTime:F3} ms");
        Debug.Log($"Frame Budget Delta: {frameBudgetDelta:+0.000;-0.000;0.000} ms");
        Debug.Log("================================");
    }
}
