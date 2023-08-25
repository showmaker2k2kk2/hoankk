using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAriState : playerState
{
    public PlayerAriState(Player _player, playerStateMachine _StateMachine, string _animBoolName) : base(_player, _StateMachine, _animBoolName)
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
        if (player.isGroundetected())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
