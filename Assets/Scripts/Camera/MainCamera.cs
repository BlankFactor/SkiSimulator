using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Character character;
    private Animator ani;

    public bool reversed;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (character.falled)
        {
            Vector3 v3 = transform.eulerAngles;
            v3.z = Mathf.Lerp(v3.z,Mathf.Abs(character.transform.eulerAngles.z),0.01f);
            transform.eulerAngles = v3;

            if(reversed)
                reversed = false;
        }

        if (reversed)
        {
            Vector3 v3 = parent.transform.eulerAngles;
            v3.z = Mathf.Lerp(v3.z, 180, 0.06f);
            parent.transform.eulerAngles = v3;
        }
        else
        {
            Vector3 v3 = parent.transform.eulerAngles;
            v3.z = Mathf.Lerp(v3.z, 0, 0.06f);
            parent.transform.eulerAngles = v3;
        }
    }

    public void Reverse(bool _v)
    {
        reversed = _v;
    }
}
