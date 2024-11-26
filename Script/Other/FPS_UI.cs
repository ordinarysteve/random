using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPS_UI : MonoBehaviour
{
    [SerializeField] FPSCounter fps_counter;
    [SerializeField] TextMeshProUGUI fps_text;

    int frames_counter = 0;

    void Update()
    {
        if (frames_counter > fps_counter.n_frames_to_track)
        {
            fps_text.text = $"{fps_counter.fps} fps";
            frames_counter = 0;
        }
    
        frames_counter++;
    }
}
