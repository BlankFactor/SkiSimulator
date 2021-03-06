using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestRecorder : MonoBehaviour
{
    [Header("Objects")]
    public GameObject gui;
    [Space]
    public ParticleSystem wind;
    [Space]
    public TextMeshProUGUI vel_X;
    public TextMeshProUGUI vel_Y;
    public TextMeshProUGUI rateOverTime;
    public TextMeshProUGUI playbackSpeed;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            gui.SetActive(!gui.activeSelf);
        }

        vel_X.text = Mathf.Round(DataRecorder.instance.player_Velocity_X).ToString();
        vel_Y.text = Mathf.Round(DataRecorder.instance.player_Velocity_Y).ToString();
        rateOverTime.text = wind.emissionRate.ToString();
        playbackSpeed.text = wind.main.simulationSpeed.ToString();
    }
}
