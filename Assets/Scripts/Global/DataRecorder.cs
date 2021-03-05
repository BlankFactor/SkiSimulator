using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRecorder : MonoBehaviour
{
    [HideInInspector]
    public static DataRecorder instance;

    [Header("Datas")]
    public float player_Velocity_X;
    public float player_Velocity_Y;

    public int min;
    public int sec;

    [Header("Objects")]
    public Rigidbody2D player_Rig;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player_Velocity_X = player_Rig.velocity.x;
        player_Velocity_Y = player_Rig.velocity.y;

        min = (int)(Time.time / 60);
        sec = (int)(Time.time % 60);

        player_Velocity_X = Mathf.Clamp(player_Velocity_X,0, Mathf.Infinity);
    }

    public void ResetTime()
    {
        min = sec = 0;
    }
}
