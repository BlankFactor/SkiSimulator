using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform follow;

    public bool keepHeight;

    private Vector2 offset;
    private float pos_Y;
    void Start()
    {
        pos_Y = transform.position.y;
        offset = transform.position - follow.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (keepHeight)
        {
            Vector2 np = (Vector2)follow.position + offset;
            np.y = pos_Y;
            transform.position = np;
        }
        else
        {
            transform.position = (Vector2)follow.position + offset;
        }    
    }
}
