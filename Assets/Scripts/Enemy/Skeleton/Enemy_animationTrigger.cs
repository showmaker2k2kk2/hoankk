using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_animationTrigger : MonoBehaviour
{
    private EnemySkeleton enemy => GetComponentInParent<EnemySkeleton>();
    private void OpenCouterWindown()
    {
        enemy.OpenCounterAttackWindown();
    }

    private void ClosecouterAttackWindown()
    {
        enemy.closeCouterAttackWindown();
    }
}