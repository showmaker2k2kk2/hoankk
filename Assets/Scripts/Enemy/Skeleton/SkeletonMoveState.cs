using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMoveState : SelctonGroundState
{
    public SkeletonMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, EnemySkeleton _enemy) : base(_enemyBase, _stateMachine, _animboolName, _enemy)
    {
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

        enemy.SetVelocity(enemy.movespeed * enemy.facingDir, rb.velocity.y);
        if (!enemy.isGroundetected())
        {
            enemy.Flip();
            stateMachine.changerState(enemy.idleState);
        }
    

    }
}
