using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStun : Enemystate
{
    private EnemySkeleton enemy;
    public EnemyStun(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animboolName, EnemySkeleton _enemy) : base(_enemyBase, _stateMachine, _animboolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.fx.InvokeRepeating("RedcolorBlink",0,0.1f);
        stateTimer = enemy.Stunduration;
        rb.velocity=new Vector2(-enemy.facingDir * enemy.StunDirection.x, enemy.StunDirection.y);

    }

    public override void Exit()
    {
        base.Exit();
        enemy.fx.Invoke("CancelReadblink", 0);
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
        {
            stateMachine.changerState(enemy.idleState); 
        }
    }
}
