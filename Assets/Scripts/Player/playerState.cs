using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState 
{
    protected playerStateMachine stateMachine;
    protected Player player;

    protected Rigidbody2D rb; 

    protected float xInput;
    private string animBoolName;
    protected float stateTimer;
    protected bool triggercalled;
        



    public playerState(Player _player, playerStateMachine _StateMachine, string _animBoolName)

    {
        this.player = _player;
        this.stateMachine = _StateMachine;
        this.animBoolName = _animBoolName;
    }
    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);  
        rb=player.rb;
        triggercalled = false;
    }
    public virtual void Update()
    {
        stateTimer-= Time.deltaTime;
        xInput = Input.GetAxis("Horizontal");
        player.anim.SetFloat("yVelocity", rb.velocity.y);
  
  
    }
    public virtual void Exit()
    {
       
        player.anim.SetBool(animBoolName, false);
    }
    public void AnimationFinishTrigger()
    {
        triggercalled=true;
    }
}
