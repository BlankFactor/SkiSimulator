using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : MonoBehaviour
{
    [HideInInspector]
    public static GUIController instance;

    [Header("Objects")]
    public Animator ani_Tip;

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

    public void DisplayTip_Restart(bool _v)
    {
        ani_Tip.SetBool("Display", _v);
    }

}
