using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/Create SkillProperty")]
public class SkillProperty : ScriptableObject
{
    public float duration;
    public float coolDown;
    public float mutiple;

    public bool prepared = true;

    private void OnDisable()
    {
        prepared = true;
    }

    private void OnEnable()
    {
        prepared = true;
    }
}
