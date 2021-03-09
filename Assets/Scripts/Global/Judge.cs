using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    [HideInInspector]
    public static Judge instance;

    public float point = 50;

    public bool judgable = false;

    public Transform trans_Player;
    public Character character;

    public Vector2 velocityLevel;
    public bool judgingVelocity;
    public float checkVelPerS = 2.0f;

    public bool judgingAngle;
    public float changedAngle;

    public float playerDis;
    public bool checkingDis;
    public float checkDisCountDown = 10f;
 
    public bool recording = false;



    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    private void OnEnable()
    {
        playerDis = trans_Player.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.CheckIfGaming() || !judgable)
            return;

        // Dis judgement
        if (trans_Player.position.x > playerDis)
            playerDis = trans_Player.position.x;
        else if(trans_Player.position.x < playerDis)
        {
            if (checkingDis) return;
            else
            {
                checkingDis = true;
                StartCoroutine(MonitorDis());
            }
        }

        // Velocity judgement
        if (!judgingVelocity)
        {
            judgingVelocity = true;
            StartCoroutine(MonitorSpeed());
        }

        if (judgable)
        {
            // Angle judgement
            if (!judgingAngle)
            {
                if (character.overGround)
                {
                    judgingAngle = true;
                    changedAngle = 0;
                }
            }
            else
            {
                if (!character.overGround)
                {
                    judgingAngle = false;

                    changedAngle = Mathf.Abs(changedAngle);

                    float np = 0;
                    if (changedAngle >= 180 && changedAngle < 360)
                    {
                        np = 4;
                    }
                    else if (changedAngle >= 360 && changedAngle < 720)
                    {
                        np = 10;
                        np += ((changedAngle - 360) / 360) * 10;
                    }
                    else if (changedAngle >= 720)
                    {
                        np = 20;
                        np += (changedAngle - 720) * 0.05f;
                    }

                    point += np;
                    Debug.Log("Angle : " + changedAngle + " Additional point : " + np);
                }
                else
                {
                    if (Input.GetKey(KeyCode.A))
                    {
                        changedAngle -= character.rotationSpeed;
                    }
                    else if (Input.GetKey(KeyCode.D))
                    {
                        changedAngle += character.rotationSpeed;
                    }
                }
            }
        }
        //point = Mathf.Clamp(point, 0, 100);

        //Debug.Log(trans_Player.eulerAngles.z);
    }

    IEnumerator MonitorSpeed()
    {
        yield return new WaitForSeconds(checkVelPerS);

        if (judgable)
        {
            if (GameManager.instance.CheckIfGaming())
            {
                if (DataRecorder.instance.player_Velocity_X > 0 && DataRecorder.instance.player_Velocity_X <= velocityLevel.x)
                {
                    point -= 3;
                }
                else if (DataRecorder.instance.player_Velocity_X > velocityLevel.x && DataRecorder.instance.player_Velocity_X <= velocityLevel.y)
                {
                    point += 1;
                }
                else if (DataRecorder.instance.player_Velocity_X > velocityLevel.y)
                {
                    point += 2;
                }
            }

            judgingVelocity = false;
        }
    }

    IEnumerator MonitorDis()
    {
        float temp = playerDis;

        yield return new WaitForSeconds(checkDisCountDown);

        if (judgable)
        {
            if (temp == playerDis)
            {
                Debug.Log("Waste");
                GameManager.instance.CeaseGame();

                point = 0;
            }
        }

        checkingDis = false;
    }

    public void PlayerFalled()
    {
        point = 0;
    }

    public void Reset()
    {
        point = 50;

        checkingDis = false;
        judgingVelocity = false;
        judgingAngle = false;

        playerDis = -7.42f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Vector3 vc = Vector3.zero;
        vc.x = playerDis;
        vc.y = 100;

        Vector3 vc2 = vc;
        vc2.y = -100;
        Gizmos.DrawLine(vc, vc2);
    }

    public void SetJudgable(bool _v)
    {
        judgable = _v;
    }
}
