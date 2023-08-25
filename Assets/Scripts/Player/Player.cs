using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Emity 
{
    [Header("attack detail")]
    public float[] AttackMovement;
  

    public bool isBusy { get; private set;  }
    [Header("move infor")]
    public float movespeed = 12f;
    public float jumpForce;

    [Header("dash infor")]
    [SerializeField] public float dashDuration;
    [SerializeField] public float dashspeed;
    [SerializeField] public float dashDir { get; private set; }
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashUsageTimer;

    #region States
    public playerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public playerMovestate movestate { get; private set; }
    public playerJumpState jumpState { get; private set; }
    public PlayerAriState AirState { get; private set; }
    public PlayerDashstate dashstate { get; private set; }
    public PlayerprimariAttackState primaryAttack { get; private set; }
    public PlayerAnimSwoed animSword { get; private set; }
    public PlayercathSwordState cathSwordState { get; private set; }
    #endregion
   protected override void Awake()
    {
        base.Awake();   
        stateMachine = new playerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "idle");
        movestate = new playerMovestate(this, stateMachine, "move");
        jumpState = new playerJumpState(this, stateMachine, "jump");
        AirState = new PlayerAriState(this, stateMachine, "jump");
        dashstate = new PlayerDashstate(this, stateMachine, "dash");
        primaryAttack = new PlayerprimariAttackState(this, stateMachine, "attack");
        animSword = new PlayerAnimSwoed(this, stateMachine, "swordAim");
        cathSwordState = new PlayercathSwordState(this, stateMachine, "cathSword    ");

    }
    protected override void Start()
    {
        base.Start();
       
        stateMachine.Initialize(idleState);

    }



    protected  override void Update()
    {

        base.Update();
        stateMachine.currentState.Update();

        CheckforDashinput();
    
   }

    public IEnumerator BusyFor(float second)
    {
        isBusy = true;
        yield return new WaitForSeconds(second);
        isBusy = false;
    }
    private void CheckforDashinput()
    {
        //if (IsWallDetected())
        //    return;
          
        dashUsageTimer -= Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.F) && dashUsageTimer < 0)
        {
            dashUsageTimer = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
                dashDir = facingDir;


            stateMachine.ChangeState(dashstate);
        }
    }

    public void AnimationTrigger()=>stateMachine.currentState.AnimationFinishTrigger();

  

}
