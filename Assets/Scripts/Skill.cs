using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    protected float cooldowmnTimer;
    protected virtual void Update()
    {
        cooldowmnTimer -= Time.time;
    }

    public virtual bool canUseSkill()
    {
        if (cooldowmnTimer < 0)
        {
            UseSkill();
            cooldowmnTimer = cooldown;
            return true;
        }
        Debug.Log("skill is on Coodown");
        return false;
    }
    public virtual void UseSkill()
    {
        
    }
}
