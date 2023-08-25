using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundestate : playerState
{
    public PlayerGroundestate(Player _player, playerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
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
            stateMachine.ChangeState(player.animSword);
        if (Input.GetKeyDown(KeyCode.E))
            stateMachine.ChangeState(player.primaryAttack);

        if (!player.isGroundetected())
            stateMachine.ChangeState(player.AirState);

        if (Input.GetKeyDown(KeyCode.Space)&& player.isGroundetected())
            stateMachine.ChangeState(player.jumpState);
    }
}
