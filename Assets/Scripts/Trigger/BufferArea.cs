using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufferArea : MonoBehaviour
{
    public float drag_Set;
    float drag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            drag = collision.GetComponent<Rigidbody2D>().drag;

            collision.GetComponent<Rigidbody2D>().drag = drag_Set;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Rigidbody2D>().drag = drag ;
        }
    }
}
