 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject left;
    public GameObject right;

    public float force;

    private Rigidbody2D rid;

    public Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        //rid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ani.SetBool("rightDown", true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ani.SetBool("rightDown", false);
        }

        if (Input.GetMouseButton(1))
        {
            ani.SetBool("leftDown", true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            ani.SetBool("leftDown", false);
        }
    }

    private void OnDrawGizmos()
    {

    }
}
