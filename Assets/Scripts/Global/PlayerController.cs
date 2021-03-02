using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public static PlayerController instance;
    public Character character;

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
        if (!GameManager.instance.CheckIfGaming())
        {


            return;
        }

        if (Input.GetMouseButton(0))
        {
            character.SetLeftDown(true);
        }else
        {
            character.SetLeftDown(false);
        }

        if (Input.GetMouseButton(1))
        {
            character.SetRightDown(true);
        }
        else
        {
            character.SetRightDown(false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            character.Grab(true);
        }
        else
        {
            character.Grab(false);
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.CheckIfGaming())
            return;

        if (Input.GetKey(KeyCode.A))
        {
            character.Rotate_Left();
        }
        if (Input.GetKey(KeyCode.D))
        {
            character.Rotate_Right();
        }
    }
}
