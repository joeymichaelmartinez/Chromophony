using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Light))]
public class LightOnAudio : MonoBehaviour {
    public int _band;
    public float _minIntesity, _maxIntensity;
    Light _light;

	// Use this for initialization
	void Start () {
        _light = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        _light.intensity = (Vizualize_R._audioBandBuffer[_band] * (_maxIntensity - _minIntesity)) + _minIntesity;
	}
}
