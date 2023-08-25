using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelctonGroundState : Enemystate
{

    private Transform player;
    protected EnemySkeleton enemy;
    public SelctonGroundState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, EnemySkeleton enemy) : base(_enemyBase, _stateMachine, _animboolName)
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
        if (enemy.isPLayerDetected())
            stateMachine.changerState(enemy.battleState);  
    }
}
