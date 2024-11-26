using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FPSCounter : MonoBehaviour
{
    public int fps { get; private set; }
    public int fpsAvg { get; private set; } // average fps valuse
    public int fpsMax { get; private set; } // maximum fps value
    public int n_frames_to_track { get; private set; } = 100;
    Queue<float> frame_rates = new Queue<float>();
    float fps_float;

    void Update()
    {
        fps_float = 1f / Time.deltaTime;
        fps = (int)fps_float;
        frame_rates.Enqueue(fps_float);
        if (frame_rates.Count > n_frames_to_track)
        {
            frame_rates.Dequeue();
        }
        fpsAvg = (int)frame_rates.Average();
        fpsMax = (int)frame_rates.Max();
    }
}
