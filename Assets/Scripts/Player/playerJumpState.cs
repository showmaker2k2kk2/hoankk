using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class playerJumpState : playerState
{
    public playerJumpState(Player _player, playerStateMachine _StateMachine, string _animBoolName) : base(_player, _StateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity = new Vector2(rb.velocity.x, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.AirState);
        }
    }
}
