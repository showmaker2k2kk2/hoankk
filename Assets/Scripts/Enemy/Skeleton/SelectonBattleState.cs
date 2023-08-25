using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectonBattleState : Enemystate
{
    private Transform player;
    private  EnemySkeleton enemy;
    private int moveDir;


    public SelectonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName,EnemySkeleton _enemy) : base(_enemyBase, _stateMachine, _animboolName)
    {
        this.enemy = _enemy;

    }

    public override void Enter()
    {
        base.Enter();
        player = PlayerManager.instance.transform;
    }



    public override void Update()
    {
        base.Update();
        if (enemy.isPLayerDetected())
        {
            if (enemy.isPLayerDetected().distance < enemy.attackDistance)
            {
                stateMachine.changerState(enemy.SkeletonAttack);
            }
        }


        if (player.position.x > enemy.transform.position.x)

        {
            moveDir = 1;


        } else if (player.position.x < enemy.transform.position.x)
        {
            moveDir = -1;
        }
        enemy.SetVelocity(enemy.movespeed * moveDir, rb.velocity.y);
    }
    public override void Exit()
    {
        base.Exit();
    }

    
}
