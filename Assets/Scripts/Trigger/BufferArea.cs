using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferArea : MonoBehaviour
{
    public float fixed_Vel;
    public float lerp;

    private bool trigger;
    private Rigidbody2D rig;
    void Start()
    {

    }

    void Update()
    {
        if (trigger)
        {
            Vector2 v2 = rig.velocity;
            v2.x = Mathf.Lerp(v2.x, fixed_Vel, lerp);

            rig.velocity = v2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trigger = true;
            rig = collision.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trigger = false;
            Vector2 v2 = rig.velocity;
            v2.x = 0;
            rig.velocity = v2;
            rig = null;
        }
    }
}
