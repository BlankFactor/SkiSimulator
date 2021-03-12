using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour,ISkill
{
    public SkillProperty property;

    float distance = 20;

    public void Recall(Character _character)
    {

    }

    public void Reflash()
    {
        property.prepared = true;
    }

    public void Release(Character _character)
    {
        if (!property.prepared || !_character.overGround)
            return;

        Gizmos.color = Color.blue;
        Vector2 v = _character.transform.position + _character.transform.right * _character.blinkDistance;

        _character.transform.position = v;

        SkillManager.instance.InvokeReflash(this, property);
    }
}
