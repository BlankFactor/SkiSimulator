using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerController instance;
    public Character character;
    public Animator ani;
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
        if (Input.GetMouseButton(0))
        {
            ani.SetBool("leftDown", true);
        }else
        {
            ani.SetBool("leftDown", false);
        }

        if (Input.GetMouseButton(1))
        {
            ani.SetBool("rightDown", true);
        }
        else
        {
            ani.SetBool("rightDown", false);
        }
    }

    private void FixedUpdate()
    {

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
