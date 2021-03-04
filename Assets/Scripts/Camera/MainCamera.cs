using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Character character;
    private Animator ani;
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
        }
    }
}
