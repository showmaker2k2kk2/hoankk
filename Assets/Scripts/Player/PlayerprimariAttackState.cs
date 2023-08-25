using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerprimariAttackState : playerState
{

    private int comboCounter;
    private float lastTimeAttack;
    private float ComboWindown=2;
    public PlayerprimariAttackState(Player _player, playerStateMachine _StateMachine, string _animBoolName) : base(_player, _StateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (comboCounter > 2||Time.time>=lastTimeAttack+ComboWindown)
            comboCounter = 0;
        player.anim.SetInteger("Combocounter", comboCounter);

        #region choose attackdirection
        float attackDir = player.facingDir;
        if(xInput!=0)
            attackDir=xInput;

        #endregion
        player.SetVelocity(player.AttackMovement[comboCounter] * attackDir, rb.velocity.y);
        stateTimer = .1f;
    }



    public override void Exit()
    {
        player.StartCoroutine("BusyFor", .1f    );
        base.Exit();
        comboCounter++;
        lastTimeAttack = Time.time;
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
            rb.velocity = new Vector2(0, 0);

        if (triggercalled)
            stateMachine.ChangeState(player.idleState);
    }
}
