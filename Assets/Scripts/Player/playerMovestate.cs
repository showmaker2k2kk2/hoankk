using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovestate : PlayerGroundestate
{
    public playerMovestate(Player _player, playerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
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

        player.SetVelocity(xInput * player.movespeed,rb.velocity.y);   
        if (xInput == 0)
            stateMachine.ChangeState(player.idleState);
    }
}
