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

    ISkill skill;
    SkillProperty property;
    private void Awake()
    {
        instance = this;

        reverseGravity = gameObject.AddComponent<ReverseGravity>();
        reverseGravity.hideFlags = HideFlags.HideInInspector;
    }

    public ReverseGravity GetSkill_ReverseGravity()
    {
        return reverseGravity;
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

    public void Reflash(ISkill _skill, float _duration)
    {

    }
}
