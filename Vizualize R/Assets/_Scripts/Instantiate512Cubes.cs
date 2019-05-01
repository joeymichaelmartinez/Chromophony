using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour {
    public GameObject _sampleCubePrefab;
    GameObject[] _sampleCube = new GameObject[512];
    public float _maxScale;
    Material _material;
    Color _color;
    float _red, _green,_blue;
	// Use this for initialization
	void Start () {
        _material = GetComponent<MeshRenderer>().materials[0];
        _red = 0;
        _green = 0;
        _blue = 0;
        for (int i = 0; i < 512; i++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate(_sampleCubePrefab);
            // _instanceSampleCube.GetComponents<MeshRenderer>().materials[0];
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            _instanceSampleCube.transform.position = Vector3.forward * 100;
            _sampleCube[i] = _instanceSampleCube;
            _red += 0.01f;
            _green += 0.01f;
            _blue += 0.01f;
            _color = new Color(1,1,1);
            _material.SetColor("_EmissionColor", _color);
        }
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < 512; i++)
        {
            if (_sampleCube != null)
            {
                _sampleCube[i].transform.localScale = new Vector3(10, (Vizualize_R._samples[i] * _maxScale) + 2, 10);
            }
        }
	}
}
