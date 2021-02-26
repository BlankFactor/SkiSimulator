using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody2D rig_Ski;
    public Transform tf_Ski;

    public float force;
    public float rotationSpeed;

    public bool falled;
    public bool overGround;

    public bool readyToJump_Left = false;
    public bool readyToJump_Right = false;

    public GameObject leftPoint;
    public GameObject rightPoint;

    public Vector2 checkPoint_Left;
    public Vector2 checkPoint_Right;
    public float Checklength;

    public LayerMask layer_Gronud;

    private FixedJoint2D joint;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<FixedJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(joint == null && !falled)
        {
            Fall();
        }

        RaycastHit2D hit = Physics2D.Raycast(leftPoint.transform.position,tf_Ski.up * -1,Checklength,layer_Gronud);
        if (hit.collider != null && hit.collider.tag == "Ground")
        {
            readyToJump_Left = true;
        }
        else
        {
            readyToJump_Left = false;
        }

        hit = Physics2D.Raycast(rightPoint.transform.position, tf_Ski.up * -1, Checklength, layer_Gronud);

        if (hit.collider != null && hit.collider.tag == "Ground")
        {
            readyToJump_Right = true;
        }
        else
        {
            readyToJump_Right = false;
        }

        if (!readyToJump_Left && !readyToJump_Right)
            overGround = true;
        else
            overGround = false;
    }

    public void AddForceAtLeft()
    {
        if (!readyToJump_Left)
            return;
        rig_Ski.AddForceAtPosition(tf_Ski.transform.up * force, leftPoint.transform.position);
    }
    public void AddForceAtRight()
    {
        if (!readyToJump_Right)
            return;
        rig_Ski.AddForceAtPosition(tf_Ski.transform.up * force, rightPoint.transform.position);
    }

    public void OnDrawGizmos()
    {
        if (readyToJump_Left)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawLine((Vector2)leftPoint.transform.position, (Vector2)leftPoint.transform.position + (Vector2)tf_Ski.up * -1 * Checklength);

        if (readyToJump_Right)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawLine((Vector2)rightPoint.transform.position, (Vector2)rightPoint.transform.position + (Vector2)tf_Ski.up * -1 * Checklength);
    }

    public void Rotate_Left()
    {
        if (!overGround) return;

        transform.Rotate(Vector3.forward * rotationSpeed);
    }

    public void Rotate_Right()
    {
        if (!overGround) return;

        transform.Rotate(Vector3.forward * rotationSpeed * -1); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (falled)
            return;

        if (collision.transform.tag == "Ground")
        {
            if (joint)
            {
                Fall();
                joint.enabled = false;
            }
        }
    }

    void Fall()
    {
        falled = true;
        GetComponent<Animator>().SetBool("Falled", falled);
        GetComponent<CapsuleCollider2D>().direction = CapsuleDirection2D.Horizontal;
    }
}
