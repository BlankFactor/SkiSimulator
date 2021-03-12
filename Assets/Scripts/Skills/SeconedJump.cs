using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeconedJump : MonoBehaviour,ISkill
{
    public SkillProperty property;

    bool trigger;
    Character character;

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

        Vector2 v2 = _character.GetRig().velocity;
        v2.y = 0;
        _character.GetRig().velocity = v2;

        _character.GetRig().AddForce(Vector2.up * _character.force * property.mutiple);

        SkillManager.instance.InvokeReflash(this, property);
    }
}
