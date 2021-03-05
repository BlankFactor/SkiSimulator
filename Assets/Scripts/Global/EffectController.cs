using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [HideInInspector]
    public static EffectController instance;

    public ParticleSystem wind;
    public bool windEnable;
    public float maxSpeed = 3.0f;
    public float maxRate = 60.0f;
    public float threshold_Wind = 10.0f;
    public float factor_Speed = 0.05f;
    public float factor_Rate = 0.1f;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {
        if (!windEnable)
        {
            if(DataRecorder.instance.player_Velocity_X >= threshold_Wind)
            {
                windEnable = true;
                wind.Play();
            }
        }
        else
        {
            if (DataRecorder.instance.player_Velocity_X < threshold_Wind)
            {
                windEnable = false;

                Reset();
            }

            wind.playbackSpeed = 1.0f + (DataRecorder.instance.player_Velocity_X - threshold_Wind) * factor_Speed;
            wind.emissionRate = 10.0f + (DataRecorder.instance.player_Velocity_X - threshold_Wind) * factor_Rate;

            wind.emissionRate = Mathf.Clamp(wind.emissionRate, 20.0f, maxRate);
            wind.playbackSpeed = Mathf.Clamp(wind.playbackSpeed, 1.0f, maxSpeed);
        }
    }
    
    public void Reset()
    {
        wind.playbackSpeed = 1.0f;
        wind.emissionRate = 20.0f;
        wind.Stop();    
    }
}
