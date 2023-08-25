using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : SelctonGroundState
{
    public SkeletonIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, EnemySkeleton _enemy) : base(_enemyBase, _stateMachine, _animboolName, _enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy.idleTime;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
            stateMachine.changerState(enemy.moveState);
      

    }
}
