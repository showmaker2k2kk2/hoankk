using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundestate
{
    public PlayerIdleState(Player _player, playerStateMachine _StateMachine, string _animBoolName) : base(_player, _StateMachine, _animBoolName)
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
        if (xInput != 0&&!player.isBusy)             
            stateMachine.ChangeState(player.movestate);
        
    }
}
