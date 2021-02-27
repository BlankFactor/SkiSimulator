using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ski : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rig;

    public Character character;
    private Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();

        pos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!character.falled)
        {
            transform.localPosition = pos;
        }

        ani.SetFloat("velocity_X", rig.velocity.x);
    }
}
