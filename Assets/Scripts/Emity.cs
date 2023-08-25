using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emity : MonoBehaviour
{

    #region component
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public EmtytiFx fx { get; private set; }
    #endregion
    [Header("Knock Back info")]
    [SerializeField] protected Vector2 KnockbackDirection;
    [SerializeField] protected float KnockbackDuration;
    protected bool isKnocked;

    [Header("Collision")]
    public Transform attackcheck;   
    public float attackcheckRadius;
    [SerializeField] protected Transform groundcheck;
    [SerializeField] protected float groundcheckDistance;
    [SerializeField] protected Transform wallcheck;
    [SerializeField] protected float wallcheckdistance;
    [SerializeField] protected LayerMask whatisGround;  

    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;

    protected virtual void Awake()
    {
        
    }
    protected virtual void Start()
    {
        fx = GetComponentInChildren<EmtytiFx>();   
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    protected virtual void Update()
    {
      

    }
    public virtual void Damage()
    {
        fx.StartCoroutine("FlashFx");
        StartCoroutine("HitKnocKback");
        Debug.Log(gameObject.name + "i dame");

    }
    protected virtual IEnumerator HitKnocKback()
    {
        isKnocked = true;
        rb.velocity = new Vector2(KnockbackDirection.x * -facingDir, KnockbackDirection.y);
        yield return new WaitForSeconds(KnockbackDuration);
        isKnocked=false;
    }
    #region collition
    public virtual bool isGroundetected() => Physics2D.Raycast(groundcheck.position, Vector2.down, groundcheckDistance, whatisGround);

   protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundcheck.position, new Vector3(groundcheck.position.x, groundcheck.position.y - groundcheckDistance));
        Gizmos.DrawLine(wallcheck.position, new Vector3(wallcheck.position.x + wallcheckdistance, groundcheck.position.y));
        Gizmos.DrawWireSphere(attackcheck.position, attackcheckRadius);
    }
    #endregion
    public virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    public virtual void FlipColtroler(float _x)
    {
        if (_x > 0 && !facingRight)
        {
            Flip();

        }
        else if (_x < 0 && facingRight)
        {
            Flip();
        }
    }   


    public virtual void SetZeroVelocity()
    {
        if (isKnocked)
            return;
        rb.velocity = new Vector2(0, 0);

    }

    public virtual void SetVelocity(float _xvelocity, float _yvelocity)
    {
        if (isKnocked)
            return;
        rb.velocity = new Vector2(_xvelocity, _yvelocity);

        FlipColtroler(_xvelocity);
    }
      

    
}
