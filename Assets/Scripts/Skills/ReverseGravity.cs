using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGravity : MonoBehaviour,ISkill
{
    public SkillProperty property;

    private float originalValue;

    public void Release(Character _character)
    {
        if (!property.prepared)
            return;

        originalValue = _character.GetRig().gravityScale;

        _character.GetRig().gravityScale = -(_character.GetRig().gravityScale * property.mutiple);
        _character.GetSkiRig().gravityScale = -(_character.GetSkiRig().gravityScale * property.mutiple);

        property.prepared = false;

        Vector2 vel = _character.GetRig().velocity;
        vel.x = -vel.x;
        _character.GetRig().velocity = vel;
        vel = _character.GetSkiRig().velocity;
        vel.x = -vel.x;
        _character.GetSkiRig().velocity = vel;


        SkillManager.instance.InvokeRecall(this, property);
        CameraController.instance.ReverseMainCam(true);
    }

    public void Reflash()
    {
        property.prepared = true;
    }

    public void Recall(Character _character)
    {
        if (property.prepared)
            return;

        CameraController.instance.ReverseMainCam(false);
        _character.GetRig().gravityScale = originalValue;
        _character.GetSkiRig().gravityScale = originalValue;

        Vector2 vel = _character.GetRig().velocity;
        vel.x = -vel.x;
        _character.GetRig().velocity = vel;
        vel = _character.GetSkiRig().velocity;
        vel.x = -vel.x;
        _character.GetSkiRig().velocity = vel;
    }
}
