using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [HideInInspector]
    public static CameraController instance;

    public GameObject camera_Player;
    public GameObject camera_Initial;

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
        
    }

    public void SwitchToPlayerCamera()
    {
        camera_Initial.SetActive(false);
    }
}
