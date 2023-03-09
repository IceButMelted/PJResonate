using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MicrophoneInput : MonoBehaviour
{
    public float sensitivity = 100;
    public float delay = 0.1f; // delay between level readings, in seconds
    public int numReadings = 50; // number of readings to collect before sorting
    private AudioSource audioSource;
    public float[] readings;
    public bool getValueformMic = false;
    private int currentReadingIndex = 0;
    private float timeSinceLastReading = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(null, true, 10, 44100);
        audioSource.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        //audioSource.Play();
        readings = new float[numReadings];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            getValueformMic = true;
            for (int i = 0; i < numReadings; ++i) 
            {
                readings[i] = 0;
            }
            currentReadingIndex = 0;
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            getValueformMic = false;
            //Debug.Log("Output " + string.Join(", ", readings));
        }

        //use on alphaControl02
        //getArrayfromMic();

    }
    public void  getArrayfromMic() {
        timeSinceLastReading += Time.deltaTime;
        if (timeSinceLastReading >= delay && getValueformMic == true)
        {
            float level = GetMicLevel();
            if (level < 0f)
            {
                level = 0f;
            }
            readings[currentReadingIndex] = (int)level;
            currentReadingIndex++;
            if (currentReadingIndex >= numReadings)
            {
                //Debug.Log("Output " + string.Join(", ", readings));
                currentReadingIndex = 0;
            }
            timeSinceLastReading = 0;
        }

    }

    float GetMicLevel()
    {
        float[] waveData = new float[1024];
        int micPosition = Microphone.GetPosition(null) - (1024 + 1);
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

