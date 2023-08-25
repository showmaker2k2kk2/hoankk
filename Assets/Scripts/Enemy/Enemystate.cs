using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemystate

{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemyBase;
    protected Rigidbody2D rb;

    private  string animboolName;
    protected float stateTimer;
    protected bool triggercaller;

   public Enemystate( Enemy _enemyBase,EnemyStateMachine _stateMachine, string _animboolName)
    {
        this.enemyBase = _enemyBase;
        this.stateMachine = _stateMachine;
        this.animboolName = _animboolName;
    }

    public virtual void Update()
    {
        stateTimer -= Time.time;

    }


    public virtual void Enter()
    {
        triggercaller = false;
        rb = enemyBase.rb;
        enemyBase.anim.SetBool(animboolName, true);
    }


    public virtual void Exit()
    {
        enemyBase.anim.SetBool(animboolName, false);
    }
}
