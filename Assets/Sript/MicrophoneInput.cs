using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour
{
    public float sensitivity = 100; // adjust this value to set the sensitivity of the mic input
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(null, true, 10, 44100);
        audioSource.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        audioSource.Play();
    }

    void Update()
    {
        float level = GetMicLevel();
        Debug.Log("Mic level: " + level);
    }

    float GetMicLevel()
    {
        float[] waveData = new float[1024];
        int micPosition = Microphone.GetPosition(null) - (1024 + 1); // null means the default microphone
        if (micPosition < 0) return 0;
        audioSource.clip.GetData(waveData, micPosition);
        float max = 0;
        for (int i = 0; i < 1024; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (max < wavePeak)
            {
                max = wavePeak;
            }
        }
        float rmsValue = Mathf.Sqrt(max);
        float dBValue = 20 * Mathf.Log10(rmsValue * sensitivity);
        return dBValue;
    }
}

