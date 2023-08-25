using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimSwoed : playerState
{
    public PlayerAnimSwoed(Player _player, playerStateMachine _StateMachine, string _animBoolName) : base(_player, _StateMachine, _animBoolName)
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
        if (Input.GetKeyUp(KeyCode.Mouse1))
            stateMachine.ChangeState(player.idleState);
    }
}
