using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public TextMeshProUGUI coord_X;
    public TextMeshProUGUI score;
    public TextMeshProUGUI char_Mass;
    public TextMeshProUGUI char_Force;
    public TextMeshProUGUI char_RotationSpeed;
    public TextMeshProUGUI gravity_Scale;

    [Space]
    public Slider slider_Mass;
    public Slider slider_Force;
    public Slider slider_RotationSpeed;
    public Slider slider_GravityScale;

    [Space]
    public Rigidbody2D char_Rig;

    void Start()
    {
        slider_Mass.onValueChanged.AddListener(delegate { Set_Mass(); });
        slider_Force.onValueChanged.AddListener(delegate { Set_Force(); });
        slider_RotationSpeed.onValueChanged.AddListener(delegate { Set_RotationSpeed(); });
        slider_GravityScale.onValueChanged.AddListener(delegate { Set_GravityScale(); });
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

        coord_X.text = char_Rig.transform.position.x.ToString();
        score.text = Judge.instance.point.ToString();

        char_Mass.text = char_Rig.mass.ToString();
        char_Force.text = char_Rig.GetComponent<Character>().force.ToString();
        char_RotationSpeed.text = char_Rig.GetComponent<Character>().rotationSpeed.ToString();

        gravity_Scale.text = char_Rig.gravityScale.ToString();
    }

    public void Set_Mass()
    {
        char_Rig.mass = slider_Mass.value;
    }

    public void Set_Force()
    {
        char_Rig.GetComponent<Character>().force = slider_Force.value;
    }

    public void Set_RotationSpeed()
    {
        char_Rig.GetComponent<Character>().rotationSpeed = slider_RotationSpeed.value;
    }

    public void Set_GravityScale()
    {
        char_Rig.gravityScale = slider_GravityScale.value;
        char_Rig.GetComponent<Character>().GetSkiRig().gravityScale = slider_GravityScale.value;
    }
}
