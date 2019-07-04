using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEditor.VFX;
using UnityEditor.Experimental.Rendering.HDPipeline;
using UnityEditor.VFX.UI;

public class VFX_Conductor : MonoBehaviour
{
    UnityEngine.Experimental.VFX.VisualEffect visualEffect;
    float intensity;
    float radius;
    private static GameObject VFX_01;
    private AudioData_AmplitudeBand AudioData;
    private float gravity_x, gravity_y, gravity_z;
    private Vector3 gravity_vector;
    private float addedBands;
    private float band1;
    private float band2;
    private float band3;
    private float band4;
    public float gate; 
    //private float band3;
    //private float band3;
    //private float band3;


    // Start is called before the first frame update
    void Start()
    {
        gate = 1000;
        GameObject VFX_01 = GameObject.Find("VFX_01");
        AudioData = VFX_01.GetComponent<AudioData_AmplitudeBand>();
        visualEffect = this.GetComponent<UnityEngine.Experimental.VFX.VisualEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        gate = 28;
        intensity = AudioData.Amplitude * 50;
        // Debug.Log("1: " + AudioData._freqBand[1]);
        // Debug.Log("2: " + AudioData._freqBand[2]);
        // Debug.Log("3: " + AudioData._freqBand[3]);


        radius = AudioData.Amplitude * 20;
        band3 = (AudioData._freqBand[2]) * 100;
        band4 = (AudioData._freqBand[3]) * 100;
        Debug.Log("2: " + band3);
        Debug.Log("3: " + band4);
        if (intensity > gate)
        {
            intensity *= 100;
            visualEffect.SetFloat("VFX_intensity", intensity);
        }
        else if (intensity > gate - 6)
        {
            intensity *= 50;
            visualEffect.SetFloat("VFX_intensity", intensity);
        } else
        {
            visualEffect.SetFloat("VFX_intensity", 0);
        }

        if(band3 > 80 && intensity > gate + 10)
        {
            intensity *= 100;
            visualEffect.SetFloat("VFX_intensity_2", band4);
        } else
        {
            visualEffect.SetFloat("VFX_intensity_2", 0);
        }
        visualEffect.SetFloat("VFX_intensity_2", band4);
        visualEffect.SetFloat("VFX_radius", radius);
        
        band1 = AudioData._freqBand[0] * -20;
        band2 = AudioData._freqBand[5] * 20;
        addedBands = band1 + band2;
        gravity_z = addedBands;
        gravity_x = 0;
        gravity_y = 0;
        gravity_vector = new Vector3(gravity_x,gravity_y,gravity_z);
        visualEffect.SetVector3("VFX_gravity", gravity_vector);
    }
}
