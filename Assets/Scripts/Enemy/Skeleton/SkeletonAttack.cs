using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : Enemystate
{
    private EnemySkeleton enemy;
    public SkeletonAttack(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, EnemySkeleton enemy) : base(_enemyBase, _stateMachine, _animboolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        enemy.SetZeroVelocity();
        if (triggercaller)
            stateMachine.changerState(enemy.battleState);
    }
}
