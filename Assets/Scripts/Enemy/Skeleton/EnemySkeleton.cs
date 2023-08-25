using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : Enemy
{

    #region state
    public SkeletonIdleState idleState { get; private set; }
    public SkeletonMoveState moveState { get; private set; }
    public SelectonBattleState battleState { get; private set; }
    public SkeletonAttack SkeletonAttack { get; private set; }
    public EnemyStun skeletonstun { get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();
        idleState= new SkeletonIdleState(this,stateMachine,"idle",this);
        moveState = new SkeletonMoveState(this, stateMachine, "Move", this);
        battleState = new SelectonBattleState(this, stateMachine, "Move", this);
        SkeletonAttack = new SkeletonAttack(this, stateMachine, "Attack", this);
        skeletonstun = new EnemyStun(this, stateMachine, "stun", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Inlitialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
}
