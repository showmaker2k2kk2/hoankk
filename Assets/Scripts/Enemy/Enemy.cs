using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy :Emity
{

    [SerializeField] protected LayerMask whatisLayer;
    [Header("Move info")]
    public float movespeed;
    public float idleTime;

    [Header("stun info")]
    public float Stunduration;
    public Vector2 StunDirection;
    protected bool canBeingstuned;
    [SerializeField] protected GameObject couterImage;


    [Header("attack info")]
    public float attackDistance;    
    public EnemyStateMachine stateMachine { get; private set; }
 protected override void Awake()
    {   
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }
    protected override void Update()
    {
        base.Update();
        stateMachine.currenState.Update();
    }
    public virtual void OpenCounterAttackWindown()
    {
         canBeingstuned = true;
        couterImage.SetActive(true);

    }
    public virtual void closeCouterAttackWindown()
    {
        canBeingstuned = false;
        couterImage.SetActive(false);
    }
    public virtual RaycastHit2D isPLayerDetected() => Physics2D.Raycast(wallcheck.position, Vector2.right * facingDir, 50, whatisGround);

    protected override void Start()
    {
        base.Start();

    }
  protected override void OnDrawGizmos() 
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x+ attackDistance * facingDir, transform.position.y));

    }
}

