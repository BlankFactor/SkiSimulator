using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;
public class SkillManager : MonoBehaviour
{
    [HideInInspector]
    public static SkillManager instance;

    public Character character;

    private ReverseGravity reverseGravity;
    private SpeedUp speedUp;
    private SeconedJump secondJump;
    private Blink blink;

    ISkill skill;
    SkillProperty property;
    private void Awake()
    {
        instance = this;

        reverseGravity = gameObject.AddComponent<ReverseGravity>();
        reverseGravity.hideFlags = HideFlags.HideInInspector;

        speedUp = gameObject.AddComponent<SpeedUp>();
        speedUp.hideFlags = HideFlags.HideInInspector;

        secondJump = gameObject.AddComponent<SeconedJump>();
        secondJump.hideFlags = HideFlags.HideInInspector;

        blink = gameObject.AddComponent<Blink>();
        blink.hideFlags = HideFlags.HideInInspector;
    }

    public ReverseGravity GetSkill_ReverseGravity()
    {
        return reverseGravity;
    }
    public SpeedUp Get_SpeedUp()
    {
        return speedUp;
    }
    public SeconedJump Get_SeconedJump()
    {
        return secondJump;
    }
    public Blink Get_Blink()
    {
        return blink;
    }

    public void InvokeRecall(ISkill _skill,SkillProperty _property)
    {
        skill = _skill;
        property = _property;

        Invoke("Recall",property.duration);
    }
    private void Recall()
    {
        skill.Recall(character);
        Invoke("Reflash", property.coolDown);
        
    }
    void Reflash()
    {
        skill.Reflash();
    }

    public void InvokeReflash(ISkill _skill, SkillProperty _property)
    {
        skill = _skill;
        Invoke("Reflash", _property.coolDown);
    }

    public void CancelInvoke_Cus()
    {
        if (IsInvoking())
        {
            CancelInvoke();
        }
    }
}
