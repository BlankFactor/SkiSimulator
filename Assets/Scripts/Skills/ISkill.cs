using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    void Release(Character _character);
    void Recall(Character _character);

    void Reflash();
}
