using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [HideInInspector]
    public static CameraController instance;

    public GameObject camera_Player;
    public GameObject camera_Initial;

    public Animator ani_MainCam;

    public Character character;

    public CinemachineVirtualCamera mainVC;
    private float defaultSize;
    private float currentSize;
    public float size_Grab;
    public float blendSpeed = 0.1f;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        defaultSize = mainVC.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        ani_MainCam.SetBool("overGround", character.overGround);

        if (!GameManager.instance.CheckIfGaming()) return;

        if (character.grabed)
        {
            mainVC.m_Lens.OrthographicSize = Mathf.Lerp(mainVC.m_Lens.OrthographicSize, size_Grab, blendSpeed);
        }
        else
        {
            mainVC.m_Lens.OrthographicSize = Mathf.Lerp(mainVC.m_Lens.OrthographicSize, defaultSize, blendSpeed);
        }
    }

    public void SwitchToPlayerCamera()
    {
        camera_Initial.SetActive(false);
    }

    public void SetMainAniamtor(string _status,bool _v)
    {
        ani_MainCam.SetBool(_status, _v);
    }

    public void SetEnableMainAnimator(bool _v)
    {
        ani_MainCam.enabled = _v;
    }

    public void ShakeCamera()
    {
        ani_MainCam.Play("Shake");
    }
}
