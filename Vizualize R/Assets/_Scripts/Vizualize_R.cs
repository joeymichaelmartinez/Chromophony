using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class Vizualize_R : MonoBehaviour {
    AudioSource _audioSource;
    public static float[] _samples = new float[512];
    private static float[] _freqBand = new float[8];
    private static float[] _bandBuffer = new float[8];
    float[] _bufferDecrease = new float[8];

    float[] _freqBandHigest = new float[8];
    public static float[] _audioBand = new float[8];
    public static float[] _audioBandBuffer = new float[8];

    public static float _Amplitude, _AmplitudeBuffer;
    float amplitudeHighest;

    // Use this for initialization
    void Start () {
        _audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
        getAmplitude();
    }

    void getAmplitude()
    {
        float currentAmplitude = 0;
        float currentAmplitudeBuffer = 0;
        for(int i = 0; i < 8; i++)
        {
            currentAmplitude += _audioBand[i];
            currentAmplitudeBuffer += _audioBandBuffer[i];
            if(currentAmplitude > amplitudeHighest)
            {
                amplitudeHighest = currentAmplitude;
            }
            _Amplitude = currentAmplitude / amplitudeHighest;
            _AmplitudeBuffer = currentAmplitudeBuffer / amplitudeHighest;
        }
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    void CreateAudioBands()
    {
        for(int i = 0; i < 8; i++)
        {
            if(_freqBand[i] > _freqBandHigest[i])
            {
                _freqBandHigest[i] = _freqBand[i];
            }
            _audioBand[i] = (_freqBand[i] / _freqBandHigest[i]);
            _audioBandBuffer[i] = (_bandBuffer[i] / _freqBandHigest[i]);
        }
    }

    void BandBuffer()
    {
        for(int i = 0; i < 8; i++)
        {
            if(_freqBand[i] > _bandBuffer[i])
            {
                _bandBuffer[i] = _freqBand[i];
                _bufferDecrease[i] = 0.005f;
            }

            if(_freqBand[i] < _bandBuffer[i])
            {
                _bandBuffer[i] -= _bufferDecrease[i];
                _bufferDecrease[i] *= 1.2f;
            }
        }
    }

    void MakeFrequencyBands()
    {
        int count = 0;

        for(int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }
            for(int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }
            average /= sampleCount;

            _freqBand[i] = average * 10;
        }
    }
}
