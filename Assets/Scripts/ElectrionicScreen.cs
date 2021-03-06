using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElectrionicScreen : MonoBehaviour
{
    public TextMeshPro tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp.text = (Mathf.Floor(Judge.instance.point)).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = (Mathf.Floor(Judge.instance.point)).ToString();
    }
}
