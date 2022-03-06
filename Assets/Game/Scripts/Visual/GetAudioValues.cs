using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAudioValues: MonoBehaviour {

    private AudioSource audioSource;
    private float[] sampleBuffer;
    private float[] samples;
    [System.NonSerialized]
    public float medium;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        sampleBuffer = new float[512];
        samples = new float[512];
    }

    void Update() {
        medium = 0f;
        audioSource.GetSpectrumData(sampleBuffer, 0, FFTWindow.BlackmanHarris);
        foreach (float sample in sampleBuffer)
            medium += sample;
        medium /= 512;

        medium *= (500 / audioSource.volume);
    }
}