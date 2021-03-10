using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clound : MonoBehaviour
{
    public Transform leftP;
    public Transform rightP;

    public float speed = -2.0f;
    public float originSpeed = -2.0f;
    public float speedFacotr = 0.01f;
    public float threadhold_Vel = 10f;

    public float direction = -1;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v2 = transform.position;

        if (DataRecorder.instance.player_Velocity_X >= threadhold_Vel)
        {
            speed = originSpeed + speedFacotr * DataRecorder.instance.player_Velocity_X * direction;
        }
        else
            speed = originSpeed;

        v2.x -= speed * Time.deltaTime * direction;

        v2.x = Mathf.Clamp(v2.x, leftP.transform.position.x, rightP.transform.position.x);

        if(v2.x == leftP.transform.position.x)
        {
            v2.x = rightP.transform.position.x;
        }

        transform.position = v2;
    }

}
