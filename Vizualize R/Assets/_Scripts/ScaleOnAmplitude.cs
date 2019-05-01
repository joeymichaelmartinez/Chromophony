using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnAmplitude : MonoBehaviour {
    public float _startScale, _maxScale;
    public bool _useBuffer;
    public float _red, _green, _blue;
    Material _material;

    // Use this for initialization
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (_useBuffer)
        {
            transform.localScale = new Vector3((Vizualize_R._Amplitude *_maxScale) + _startScale, (Vizualize_R._Amplitude * _maxScale) + _startScale, (Vizualize_R._Amplitude * _maxScale) + _startScale);
            Color _color = new Color(_red * Vizualize_R._Amplitude, _green * Vizualize_R._Amplitude, _blue * Vizualize_R._Amplitude);
            _material.SetColor("_EmissionColor", _color);
        }
        if (!_useBuffer)
        {
            transform.localScale = new Vector3((Vizualize_R._AmplitudeBuffer * _maxScale) + _startScale, (Vizualize_R._AmplitudeBuffer * _maxScale) + _startScale, (Vizualize_R._AmplitudeBuffer * _maxScale) + _startScale);
            Color _color = new Color(_red * Vizualize_R._AmplitudeBuffer, _green * Vizualize_R._AmplitudeBuffer, _blue * Vizualize_R._AmplitudeBuffer);
            _material.SetColor("_EmissionColor", _color);
        }
    }
}
