using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashstate : playerState

{
    public PlayerDashstate(Player _player, playerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
    }

            
    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.dashspeed * player.dashDir, 0);

      if (stateTimer > 0)       
            stateMachine.ChangeState(player.idleState);
        
       
    }
    public override void Exit()
    {
        base.Exit();

        player.SetVelocity(20f, rb.velocity.y);
    }
}
