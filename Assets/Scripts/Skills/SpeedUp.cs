using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour,ISkill
{
    public SkillProperty property;

    bool trigger;
    Character character;

    public float maxVel = 80.0f;
    public float velPerS = 80.0f;
    float curVel = 0;

    private void FixedUpdate()
    {
        if (trigger)
        {
            if(curVel != maxVel)
            {
                
                Vector2 vel = character.GetRig().velocity;
                Debug.Log(vel);
                Vector2 dir = character.transform.right;
                //dir.y = 0;

                curVel += dir.SqrMagnitude() * velPerS * Time.deltaTime;
                curVel = Mathf.Clamp(curVel, 0, maxVel);
                vel += dir * velPerS * Time.deltaTime;

                character.GetRig().velocity = vel;
            }
            else
            {
                Recall(character);
                SkillManager.instance.InvokeReflash(this, property);
            }
        }
    }

    public void Recall(Character _character)
    {
        trigger = false;
    }

    public void Reflash()
    {
        property.prepared = true;
    }

    public void Release(Character _character)
    {
        if (!property.prepared || _character.overGround)
            return;

        character = _character;
        trigger = true;
        property.prepared = false;
        curVel = 0;
    }
}
