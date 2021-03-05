using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ski : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rig;

    public Character character;
    private Vector2 pos;

    public ParticleSystem snowEffect;

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
        else
        {
            if (snowEffect.isPlaying)
                snowEffect.Stop();
        }

        ani.SetFloat("velocity_X", rig.velocity.x);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!GameManager.instance.CheckIfGaming()) return;

        if (collision.transform.tag == "Snowfield" && DataRecorder.instance.player_Velocity_X >= 5.0f)
        {
            snowEffect.Play();
        }   
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Snowfield")
        {
            snowEffect.Stop();
        }
    }
}
